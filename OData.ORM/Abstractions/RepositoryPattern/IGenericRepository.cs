using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OData.ORM.Abstractions.RepositoryPattern
{
    public interface IGenericRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity Get<TDataType>(TDataType id) where TDataType : struct;

        TEntity Get<TDataType>(TDataType id
            , Expression<Func<TEntity, object>> includes
            , Expression<Func<TEntity, bool>> predicate) where TDataType : struct;

        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, object>> includes);
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, object>> includes, Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }
}
