using OrdersManager.Core.Interfaces;
using OrdersManager.Core.Orders;
using OrdersManager.Core.Specification;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Infrastructure.Stubs
{
    public class StubDataOrderRepository : IRepository<Order>
    {
        private readonly MemoryRepository<Order> memRepository;

        public StubDataOrderRepository(MemoryRepository<Order> memRepository)
        {
            this.memRepository = memRepository;
        }

        public async Task<Order> FindById(Guid id)
        {
            return await this.memRepository.FindById(id);
        }

        public Order FindOne(ISpecification<Order> spec)
        {
            return this.memRepository.FindOne(spec);
        }

        public IEnumerable<Order> Find(ISpecification<Order> spec)
        {
            return this.memRepository.Find(spec);
        }

        public void Add(Order entity)
        {
            this.memRepository.Add(entity);
        }

        public void Remove(Order entity)
        {
            this.memRepository.Remove(entity);
        }
    }
}
