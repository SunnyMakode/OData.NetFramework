using System.Net.Http.Headers;
using System.Web.Http;
using Microsoft.AspNet.OData.Batch;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.OData.Edm;
using OData.Business.DomainClasses;
using Microsoft.Owin.Security.OAuth;
using ODataRestApiWithEntityFramework.DTOs;

namespace ODataRestApiWithEntityFramework
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services    
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            //Cross origin support
            config.EnableCors();

            config.Formatters.JsonFormatter.SupportedMediaTypes
                .Add(new MediaTypeHeaderValue("application/json"));

            //attribute routing support
            config.MapHttpAttributeRoutes();

            config.MapODataServiceRoute("odata", null, GetEdmModel(), new DefaultODataBatchHandler(GlobalConfiguration.DefaultServer));
            config.EnsureInitialized();

        }

        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder
            {
                Namespace = "ODataRestApiWithEntityFramework.Controllers",
                ContainerName = "DefaultContainer"
            };

            builder.EntitySet<Project>("Project");
            builder.EntitySet<ProjectDetail>("ProjectDetail");
            builder.EntitySet<User>("User");

            builder.Function("Signup")
                .Returns<IHttpActionResult>()
                .Parameter<UserDto>("userDto");

            builder.Function("Login")
                .Returns<IHttpActionResult>()
                .Parameter<UserDto>("userDto");

            return builder.GetEdmModel();
        }
    }
}
