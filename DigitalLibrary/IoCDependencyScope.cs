using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using StructureMap;

namespace DigitalLibrary
{
    public class IoCDependencyScope:IDependencyScope
    {
        private readonly IContainer _container;

        public IoCDependencyScope(IContainer container)
        {
            _container = container;
        }

        public void Dispose()
        {
            //_container.Dispose();
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == null)
            {
                return null;
            }
            try
            {
                return serviceType.IsAbstract || serviceType.IsInterface
                    ? _container.TryGetInstance(serviceType)
                    : _container.GetInstance(serviceType);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.GetAllInstances<object>().Where(s => s.GetType() == serviceType);
        }
    }
}