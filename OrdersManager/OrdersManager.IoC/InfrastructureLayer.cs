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
            services.AddScoped<IUnitOfWork, MemoryUnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(MemoryRepository<>));
            services.AddScoped(typeof(MemoryRepository<>), typeof(MemoryRepository<>));
            services.AddScoped<IRepository<User>, StubDataUserRepository>();
            services.AddScoped<IRepository<Order>, StubDataOrderRepository>();
            services.AddScoped<IRepository<Item>, StubDataItemRepository>();

            //services.AddSingleton()
            //container.Register(Component.For(typeof(IRepository<>), typeof(MemoryRepository<>)).ImplementedBy(typeof(MemoryRepository<>)).LifestyleSingleton());

            return services;
        }
    }
}
