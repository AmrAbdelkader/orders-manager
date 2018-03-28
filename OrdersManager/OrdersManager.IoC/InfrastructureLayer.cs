using eCommerce.InfrastructureLayer;
using Microsoft.Extensions.DependencyInjection;
using OrdersManager.Core.Interfaces;
using OrdersManager.Core.Items;
using OrdersManager.Core.Orders;
using OrdersManager.Core.Users;
using OrdersManager.Infrastructure;
using OrdersManager.Infrastructure.Stubs;

namespace OrdersManager.IoC
{
    /// <summary>
    /// Infrastructure layer dependencies
    /// </summary>
    public static class InfrastructureLayer
    {
        /// <summary>
        /// Adds the infrastructure services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddSingleton<IUnitOfWork, MemoryUnitOfWork>();
            services.AddSingleton(typeof(IRepository<>), typeof(MemoryRepository<>));
            services.AddSingleton(typeof(MemoryRepository<>), typeof(MemoryRepository<>));
            services.AddSingleton<IRepository<User>, StubDataUserRepository>();
            services.AddSingleton<IRepository<Order>, StubDataOrderRepository>();
            services.AddSingleton<IRepository<Item>, StubDataItemRepository>();
            
            return services;
        }
    }
}
