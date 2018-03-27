using Microsoft.Extensions.DependencyInjection;
using OrdersManager.Core.Domain;
using OrdersManager.Core.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrdersManager.IoC
{
    public static class DomainLayer
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddSingleton<IHandles<OrderCreated>, DomainEventHandler<OrderCreated>>();
            services.AddSingleton<IHandles<OrderItemAdded>, DomainEventHandler<OrderItemAdded>>();
            services.AddSingleton<IHandles<OrderItemRemoved>, DomainEventHandler<OrderItemRemoved>>();
            
            return services;
        }
    }
}
