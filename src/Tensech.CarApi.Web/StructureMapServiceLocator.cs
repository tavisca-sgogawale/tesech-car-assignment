using CommonServiceLocator;
using StructureMap;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tensech.CarApi.Common;

namespace Tensech.CarApi.Web
{
    public class StructureMapServiceLocator : IServiceLocator
    { 
    private readonly IContainer _container;

    public StructureMapServiceLocator(IContainer container)
    {
        _container = container;
    }

    public IEnumerable<object> GetAllInstances(Type serviceType)
    {
        try
        {
            var output = _container.GetAllInstances(serviceType);
            return Convert(output);
        }
        catch (StructureMapException ex)
        {
            throw new BaseApplicationException(FaultMessages.UnexpectedSystemException, "500");
        }
    }

    public IEnumerable<TService> GetAllInstances<TService>()
    {
        try
        {
            return _container.GetAllInstances<TService>();
        }
        catch (StructureMapException ex)
        {
            throw new BaseApplicationException(FaultMessages.UnexpectedSystemException, "500");
        }
    }

    public object GetInstance(Type serviceType)
    {
        try
        {
            return _container.GetInstance(serviceType);
        }
        catch (StructureMapException ex)
        {
            throw new BaseApplicationException(FaultMessages.UnexpectedSystemException, "500");
        }
    }

    public object GetInstance(Type serviceType, string key)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(key))
                return _container.GetInstance(serviceType);
            return _container.GetInstance(serviceType, key);
        }
        catch (StructureMapException ex)
        {
            throw new BaseApplicationException(FaultMessages.UnexpectedSystemException, "500");
        }
    }

    public TService GetInstance<TService>()
    {
        try
        {
            return _container.GetInstance<TService>();
        }
        catch (StructureMapException ex)
        {
            throw new BaseApplicationException(FaultMessages.UnexpectedSystemException, "500");
        }
    }

    public TService GetInstance<TService>(string key)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(key))
                return _container.GetInstance<TService>();
            return _container.GetInstance<TService>(key);
        }
        catch (StructureMapException ex)
        {
            throw new BaseApplicationException(FaultMessages.UnexpectedSystemException, "500");
        }
    }

    public object GetService(Type serviceType)
    {
        return _container.TryGetInstance(serviceType);
    }

    private static IEnumerable<object> Convert(IEnumerable enumerable)
    {
        return enumerable.Cast<object>().ToList();
    }
        private bool disposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (_container != null)
                    {
                        _container.Dispose();
                    }
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
