using Microsoft.Extensions.DependencyInjection;
using OrdersManager.Application.Orders;

namespace OrdersManager.IoC
{
    /// <summary>
    /// Application layer dependencies
    /// </summary>
    public static class ApplicationLayer
    {
        /// <summary>
        /// Adds the application services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IOrderService, OrderService>();
            return services;
        }
    }
}
