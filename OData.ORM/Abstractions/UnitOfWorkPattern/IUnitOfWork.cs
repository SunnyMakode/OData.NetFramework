using System;
using System.Threading.Tasks;
using OData.ORM.Abstractions.RepositoryPattern;

namespace OData.ORM.Abstractions.UnitOfWorkPattern
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
        Task<int> SaveChangesAsync();
        IGenericRepository<T> Repository<T>() where T : class;
    }
}
