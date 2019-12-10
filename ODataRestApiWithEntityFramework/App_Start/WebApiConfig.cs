

using System.Web.Http;
using Microsoft.AspNet.OData.Batch;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.OData.Edm;
using OData.Business.DomainClasses;

namespace ODataRestApiWithEntityFramework
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
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


            return builder.GetEdmModel();
        }
    }
}
