using OrdersManager.Core.Interfaces;
using OrdersManager.Core.Items;
using OrdersManager.Core.Specification;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrdersManager.Infrastructure.Stubs
{
    public sealed class StubDataItemRepository : IRepository<Item>
    {
        readonly MemoryRepository<Item> memRepository;

        public StubDataItemRepository(MemoryRepository<Item> memRepository)
        {
            this.memRepository = memRepository;

            this.memRepository.Add(Item.Create(new Guid("970d5366-20b3-4f8d-87a6-973cba45c538"),
                "GTA V For Play Station", 49.00));

            this.memRepository.Add(Item.Create(new Guid("39b6448e-564c-460c-be06-55fdc31f866d"),
                "Arduino Stater kit", 100.00));

            this.memRepository.Add(Item.Create(new Guid("35b00b6e-7918-4f70-b0e1-75b4a23a835c"),
                "Manchester Bee Logo <3", 20.02));
        }

        public async Task<Item> FindById(Guid id)
        {
            return await this.memRepository.FindById(id);
        }

        public async Task<Item> FindOne(ISpecification<Item> spec)
        {
            return await this.memRepository.FindOne(spec);
        }

        public async Task<IEnumerable<Item>> Find(ISpecification<Item> spec)
        {
            return await this.memRepository.Find(spec);
        }

        public async Task Add(Item entity)
        {
            this.memRepository.Add(entity);
        }

        public async Task Remove(Item entity)
        {
            this.memRepository.Remove(entity);
        }
    }
}
