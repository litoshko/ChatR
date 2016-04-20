using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using ChatR.Web.Services;
using Autofac.Integration.SignalR;
using ChatR.Web.Models;
using Microsoft.AspNet.SignalR;
using AutofacDependencyResolverSignalr = Autofac.Integration.SignalR.AutofacDependencyResolver;
using AutofacDependencyResolverMvc = Autofac.Integration.Mvc.AutofacDependencyResolver;

namespace ChatR.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();

            // Register your MVC controllers.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Register your SignalR hubs.
            builder.RegisterHubs(Assembly.GetExecutingAssembly());

            // Register your Types.
            builder.RegisterType<ChatDbContext>();
            builder.RegisterType<ChatStorage>().As<IChatStorage>();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolverMvc(container));
            GlobalHost.DependencyResolver = new AutofacDependencyResolverSignalr(container);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
