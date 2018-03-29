using Microsoft.Extensions.DependencyInjection;
using OrdersManager.Core.Domain;
using OrdersManager.Core.Orders;

namespace OrdersManager.IoC
{
    /// <summary>
    /// Domain layer dependencies
    /// </summary>
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
