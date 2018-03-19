using Microsoft.Extensions.DependencyInjection;
using OrdersManager.Application.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrdersManager.IoC
{
    public static class ApplicationLayer
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IOrderService, OrderService>();
            return services;
        }
    }
}
