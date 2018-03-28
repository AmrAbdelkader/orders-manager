using OrdersManager.Core.Domain;
using OrdersManager.Core.Interfaces;
using OrdersManager.Core.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersManager.Infrastructure
{
    /// <summary>
    /// MemoryRepository which handles storage transactions in Memory 
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <seealso cref="OrdersManager.Core.Interfaces.IRepository{TEntity}" />
    public class MemoryRepository<TEntity> : IRepository<TEntity>
        where TEntity : IAggregateRoot
    {
        /// <summary>
        /// The entities
        /// </summary>
        protected static List<TEntity> entities = new List<TEntity>();

        /// <summary>
        /// Finds the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<TEntity> FindById(Guid id)
        {
            return entities.Where(x => x.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Finds the one.
        /// </summary>
        /// <param name="spec">The spec.</param>
        /// <returns></returns>
        public async Task<TEntity> FindOne(ISpecification<TEntity> spec)
        {
            return entities.Where(spec.IsSatisfiedBy).FirstOrDefault();
        }

        /// <summary>
        /// Finds the specified spec.
        /// </summary>
        /// <param name="spec">The spec.</param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> Find(ISpecification<TEntity> spec)
        {
            return entities.Where(spec.IsSatisfiedBy);
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public async Task Add(TEntity entity)
        {
            entities.Add(entity);
        }

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public async Task Remove(TEntity entity)
        {
            entities.Remove(entity);
        }
    }
}
