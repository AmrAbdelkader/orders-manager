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
            services.AddSingleton(typeof(IRepository<>), typeof(MemoryRepository<>));
            services.AddSingleton(typeof(MemoryRepository<>), typeof(MemoryRepository<>));
            services.AddSingleton<IRepository<User>, StubDataUserRepository>();
            services.AddSingleton<IRepository<Order>, StubDataOrderRepository>();
            services.AddSingleton<IRepository<Item>, StubDataItemRepository>();
            
            return services;
        }
    }
}
