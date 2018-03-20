using OrdersManager.Core.Interfaces;
using OrdersManager.Core.Specification;
using OrdersManager.Core.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Infrastructure.Stubs
{
    public sealed class StubDataUserRepository : IRepository<User>
    {
        private readonly MemoryRepository<User> memRepository;

        public StubDataUserRepository(MemoryRepository<User> memRepository)
        {
            this.memRepository = memRepository;

            User customer = User.Create(new Guid("c7daa440-096e-448b-ae45-d71268078225"), "Amr", "Elsayed", "amr.elsayed@gmail.com");
            this.memRepository.Add(customer);
        }

        public async Task<User> FindById(Guid id)
        {
            return await this.memRepository.FindById(id);
        }

        public User FindOne(ISpecification<User> spec)
        {
            return this.memRepository.FindOne(spec);
        }

        public IEnumerable<User> Find(ISpecification<User> spec)
        {
            return this.memRepository.Find(spec);
        }

        public void Add(User entity)
        {
            this.memRepository.Add(entity);
        }

        public void Remove(User entity)
        {
            this.memRepository.Remove(entity);
        }
    }
}


