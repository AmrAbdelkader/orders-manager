using OrdersManager.Core.Interfaces;
using OrdersManager.Core.Specification;
using OrdersManager.Core.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Infrastructure.Stubs
{
    public sealed class StubDataUserRepository : IDomainEventRepository<User>
    {
        private readonly MemoryRepository<User> memRepository;

        public StubDataUserRepository(MemoryRepository<User> memRepository)
        {
            this.memRepository = memRepository;

            User customer = User.Create(new Guid("c7daa440-096e-448b-ae45-d71268078225"),
                "Amr", "Elsayed", "amr.elsayed@gmail.com");
            this.memRepository.Add(customer);
        }

        public async Task<User> FindById(Guid id)
        {
            return await this.memRepository.FindById(id);
        }

        public async Task<User> FindOne(ISpecification<User> spec)
        {
            return await this.memRepository.FindOne(spec);
        }

        public async Task<IEnumerable<User>> Find(ISpecification<User> spec)
        {
            return await this.memRepository.Find(spec);
        }

        public async Task Add(User entity)
        {
            this.memRepository.Add(entity);
        }

        public async Task Remove(User entity)
        {
            this.memRepository.Remove(entity);
        }
    }
}


