using OrdersManager.Core.Domain;
using OrdersManager.Core.Interfaces;
using OrdersManager.Core.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrdersManager.Infrastructure
{
    public class MemoryRepository<TEntity> : IRepository<TEntity>
        where TEntity : IAggregateRoot
    {
        protected static List<TEntity> entities = new List<TEntity>();

        public TEntity FindById(Guid id)
        {
            return entities.Where(x => x.Id == id).FirstOrDefault();
        }

        public TEntity FindOne(ISpecification<TEntity> spec)
        {
            return entities.Where(spec.IsSatisfiedBy).FirstOrDefault();
        }

        public IEnumerable<TEntity> Find(ISpecification<TEntity> spec)
        {
            return entities.Where(spec.IsSatisfiedBy);
        }

        public void Add(TEntity entity)
        {
            entities.Add(entity);
        }

        public void Remove(TEntity entity)
        {
            entities.Remove(entity);
        }
    }
}
