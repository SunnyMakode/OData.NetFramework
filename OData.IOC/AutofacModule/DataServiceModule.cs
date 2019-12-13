using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using OData.InternalDataService.Implementation;
using OData.InternalDataService.Interface;

namespace OData.IOC.AutofacModule
{
    public class DataServiceModule : Module
    {
        public DataServiceModule(){ }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProjectRepository>().As<IProjectRepository>();
            builder.RegisterType<ProjectDetailRepository>().As<IProjectDetailRepository>();
            builder.RegisterType<AuthRepository>().As<IAuthRepository>();

            base.Load(builder);
        }
    }
}
