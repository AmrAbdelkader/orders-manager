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
        TEntity FindOne(ISpecification<TEntity> spec);
        IEnumerable<TEntity> Find(ISpecification<TEntity> spec);
        void Add(TEntity entity);
        void Remove(TEntity entity);
    }

    //public interface IRepositoryAsync<TEntity> : 
    //    IRepository<TEntity> where TEntity : IAggregateRoot
    //{
    //    Task<TEntity> FindByIdAsync(Guid id);
    //    Task<TEntity> FindOneAsync(ISpecification<TEntity> spec);
    //    Task<IEnumerable<TEntity>> FindAsync(ISpecification<TEntity> spec);
    //    Task AddAsync(TEntity entity);
    //    Task RemoveAsync(TEntity entity);
    //}

}
