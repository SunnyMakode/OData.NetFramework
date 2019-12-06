using System.Web.Http;
using System.Web.OData.Batch;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
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
                Namespace = "ODataRestAPI",
                ContainerName = "DefaultContainer"
            };

            builder.EntitySet<Project>("Project");
            builder.EntitySet<ProjectDetail>("ProjectDetail");


            return builder.GetEdmModel();
        }
    }
}
