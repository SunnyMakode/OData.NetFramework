using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OData.ORM.Abstractions.UnitOfWorkPattern;

namespace OData.InternalDataService.Implementation
{
    public class Service<TEntity> where TEntity : class
    {
        protected readonly IUnitOfWork _unitOfWork;

        public Service(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
    }
}
