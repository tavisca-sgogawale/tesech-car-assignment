using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonServiceLocator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Converters;
using StructureMap;
using Tensech.CarApi.Services;
using Tensech.CarApi.Services.Contract;

namespace Tensech.CarApi.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
                   .SetBasePath(env.ContentRootPath)
                   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                   .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                   .AddEnvironmentVariables();
            Configuration = builder.Build();
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", env.EnvironmentName);
            _environmentName = env.EnvironmentName;
        }
        private readonly string _environmentName;
        private bool _isCompressionEnabled;
        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.
                AddScoped<ICarService,CarService>().
                 AddMvc().
                 AddJsonOptions(options =>
                 {
                     options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                     options.SerializerSettings.Converters.Add(new StringEnumConverter { CamelCaseText = true });
                 });

            // ExceptionPolicy.Configure(container.GetInstance<IErrorHandler>());
            var container = SetupContainer(services);
            SetserviceLocator(container);
            var serviceProvider = container.GetInstance<IServiceProvider>();
            return serviceProvider;

        }

        private static Container SetupContainer(IServiceCollection services)
        {
            var container = new Container();
            container.Configure(config =>
            {
                config.AddRegistry<WebRegistry>();
                config.Populate(services);
            });

            return container;
        }

        private static void SetserviceLocator(Container container)
        {
            var serviceLocator = new StructureMapServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
            app.UseExceptionMiddleWare();
            app.UseContextCreationMiddleware();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
