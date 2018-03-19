using OrdersManager.Core.Interfaces;
using OrdersManager.Core.Items;
using OrdersManager.Core.Specification;
using System;
using System.Collections.Generic;

namespace OrdersManager.Infrastructure.Stubs
{
    public sealed class StubDataItemRepository : IRepository<Item>
    {
        readonly MemoryRepository<Item> memRepository;

        public StubDataItemRepository(MemoryRepository<Item> memRepository)
        {
            this.memRepository = memRepository;

            this.memRepository.Add(Item.Create(new Guid(), "iPhone", 2, 500.02m));
        }

        public Item FindById(Guid id)
        {
            return this.memRepository.FindById(id);
        }

        public Item FindOne(ISpecification<Item> spec)
        {
            return this.memRepository.FindOne(spec);
        }

        public IEnumerable<Item> Find(ISpecification<Item> spec)
        {
            return this.memRepository.Find(spec);
        }

        public void Add(Item entity)
        {
            this.memRepository.Add(entity);
        }

        public void Remove(Item entity)
        {
            this.memRepository.Remove(entity);
        }
    }
}
