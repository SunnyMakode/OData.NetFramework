using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using OData.IOC.AutofacModule;

namespace ODataRestApiWithEntityFramework.App_Start
{
    public class AutofacConfig
    {
        public static void ConfigureContainer(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // Register dependencies in controllers/
            // WebApiApplication is a class inside Global.asax.cs
            builder.RegisterControllers(typeof(WebApiApplication).Assembly);

            // Register dependencies in filter attributes
            builder.RegisterFilterProvider();

            // Register our Data dependencies
            builder.RegisterModule(new DataServiceModule());

            //Register our Service dependencies
            builder.RegisterModule(new OrmModule());

            builder.RegisterHttpRequestMessage(config);

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            // Set MVC DI resolver to use our Autofac container
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));


        }
    }
}