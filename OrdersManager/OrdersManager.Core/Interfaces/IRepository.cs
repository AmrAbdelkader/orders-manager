using OrdersManager.Core.Domain;
using OrdersManager.Core.Specification;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrdersManager.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : IAggregateRoot
    {
        TEntity FindById(Guid id);
        TEntity FindOne(ISpecification<TEntity> spec);
        IEnumerable<TEntity> Find(ISpecification<TEntity> spec);
        void Add(TEntity entity);
        void Remove(TEntity entity);
    }
}
