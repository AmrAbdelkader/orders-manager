﻿using OrdersManager.Core.Domain;
using OrdersManager.Core.Interfaces;
using OrdersManager.Core.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Infrastructure
{
    public class MemoryRepository<TEntity> : IDomainEventRepository<TEntity>
        where TEntity : IAggregateRoot
    {
        protected static List<TEntity> entities = new List<TEntity>();
            
        public async Task<TEntity> FindById(Guid id)
        {
            return entities.Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task<TEntity> FindOne(ISpecification<TEntity> spec)
        {
            return entities.Where(spec.IsSatisfiedBy).FirstOrDefault();
        }

        public async Task<IEnumerable<TEntity>> Find(ISpecification<TEntity> spec)
        {
            return entities.Where(spec.IsSatisfiedBy);
        }

        public async Task Add(TEntity entity)
        {
            entities.Add(entity);
        }

        public async Task Remove(TEntity entity)
        {
            entities.Remove(entity);
        }
    }
}
