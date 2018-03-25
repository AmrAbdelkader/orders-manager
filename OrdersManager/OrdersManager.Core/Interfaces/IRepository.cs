using OrdersManager.Core.Domain;
using OrdersManager.Core.Specification;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : IAggregateRoot
    {
        Task<TEntity> FindById(Guid id);
        Task<TEntity> FindOne(ISpecification<TEntity> spec);
        Task<IEnumerable<TEntity>> Find(ISpecification<TEntity> spec);
        Task Add(TEntity entity);
        Task Remove(TEntity entity);
    }
}
