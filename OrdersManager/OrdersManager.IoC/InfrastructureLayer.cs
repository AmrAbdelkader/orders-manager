using eCommerce.InfrastructureLayer;
using Microsoft.Extensions.DependencyInjection;
using OrdersManager.Core.Interfaces;
using OrdersManager.Core.Items;
using OrdersManager.Core.Orders;
using OrdersManager.Core.Users;
using OrdersManager.Infrastructure;
using OrdersManager.Infrastructure.Stubs;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrdersManager.IoC
{
    public static class InfrastructureLayer
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddSingleton<IUnitOfWork, MemoryUnitOfWork>();
            services.AddSingleton(typeof(IDomainEventRepository<>), typeof(MemoryRepository<>));
            services.AddSingleton(typeof(MemoryRepository<>), typeof(MemoryRepository<>));
            services.AddSingleton<IDomainEventRepository<User>, StubDataUserRepository>();
            services.AddSingleton<IDomainEventRepository<Order>, StubDataOrderRepository>();
            services.AddSingleton<IDomainEventRepository<Item>, StubDataItemRepository>();
            
            return services;
        }
    }
}
