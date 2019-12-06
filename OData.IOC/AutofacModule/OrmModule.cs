using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using OData.ORM.Abstractions.RepositoryPattern;
using OData.ORM.Abstractions.UnitOfWorkPattern;
using OData.ORM.Context;

namespace OData.IOC.AutofacModule
{
    public class OrmModule : Module
    {
        public OrmModule(){ }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new ODataDbContext()).As<DbContext>();

            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>));
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            
            base.Load(builder);
        }
    }
}
