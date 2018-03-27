using OrdersManager.Core.Domain;
using OrdersManager.Core.Specification;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrdersManager.Core.Interfaces
{
    /// <summary>
    /// IRepository specfiying the basic common operations for any repository
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IRepository<TEntity> where TEntity : IAggregateRoot
    {
        /// <summary>
        /// Finds the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<TEntity> FindById(Guid id);

        /// <summary>
        /// Finds the one.
        /// </summary>
        /// <param name="spec">The spec.</param>
        /// <returns></returns>
        Task<TEntity> FindOne(ISpecification<TEntity> spec);
        
        /// <summary>
        /// Finds the specified spec.
        /// </summary>
        /// <param name="spec">The spec.</param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> Find(ISpecification<TEntity> spec);

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task Add(TEntity entity);

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task Remove(TEntity entity);
    }
}
