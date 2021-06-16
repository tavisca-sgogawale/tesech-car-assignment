using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tensech.CarApi.Services.Contract;
using Tensech.CarApi.Services;
using StructureMap;
using Tensech.CarApi.Common;
using Tensech.CarApi.Store;
using CommonServiceLocator;

namespace Tensech.CarApi.Web
{
    public class WebRegistry : Registry
    {
        public WebRegistry()
        {
            
            new ConfigurationBuilder();

            For<IServiceLocator>().Use<StructureMapServiceLocator>();
            For<ITokenService>().Use<TokenService>();
            if(KeyStore.Store.StoreName == KeyStore.Store.DynamoDbStoreName)
            {
                For<ICarStore>().Use<CarDynamoDBStore>().Named(KeyStore.Store.DynamoDbStoreName).Singleton();
            }
            else
            {
                For<ICarStore>().Use<CarMockStore>().Named(KeyStore.Store.MockStoreName).Singleton();
            }

            For<ICarStore>().Use<CarDynamoDBStore>().Named(KeyStore.Store.DynamoDbStoreName).Singleton();

        }
    }
}
