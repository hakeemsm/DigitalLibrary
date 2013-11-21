using System.Web.Http.Dependencies;
using StructureMap;

namespace DigitalLibrary
{
    public class StructureMapDependencyResolver: IoCDependencyScope, IDependencyResolver
    {
        private readonly IContainer _container;

        public StructureMapDependencyResolver(IContainer container):base(container)
        {
            _container = container;
        }

        

        public IDependencyScope BeginScope()
        {
            return new IoCDependencyScope(_container);
        }
    }
}