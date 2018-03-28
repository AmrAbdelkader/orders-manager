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

            this.memRepository.Add(Order.Create(new Guid("2143d854-0982-44b5-9c5d-acfaf3b7236a"),
                new Guid("c7daa440-096e-448b-ae45-d71268078225")));
        }

        public async Task<Order> FindById(Guid id)
        {
            return await this.memRepository.FindById(id);
        }

        public async Task<Order> FindOne(ISpecification<Order> spec)
        {
            return await this.memRepository.FindOne(spec);
        }

        public async Task<IEnumerable<Order>> Find(ISpecification<Order> spec)
        {
            return await this.memRepository.Find(spec);
        }

        public async Task Add(Order entity)
        {
            this.memRepository.Add(entity);
        }

        public async Task Remove(Order entity)
        {
            this.memRepository.Remove(entity);
        }
    }
}
