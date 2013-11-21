using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace DigitalLibrary
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ObjectFactory.Initialize(x=>x.AddRegistry(new IoCRegistry()));
            //var container = new Container(x=>x.AddRegistry(new IoCRegistry()));
            
            GlobalConfiguration.Configuration.DependencyResolver=new StructureMapDependencyResolver(ObjectFactory.Container);
        }
    }

    public class IoCRegistry : Registry
    {
        public IoCRegistry()
        {
            For<IBookRepository>().Singleton().Use<BookRepository>();
        }
    }
}
