using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using WebApplicationTestMVC.Abstract;
using WebApplicationTestMVC.Models;
using Autofac.Integration.Mvc;
using System.Reflection;
using WebApplicationTestMVC.Concrete;

namespace WebApplicationTestMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Register();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetCallingAssembly());
            builder.RegisterType<EFProductRepository>().As<IEFProductRepository>();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
