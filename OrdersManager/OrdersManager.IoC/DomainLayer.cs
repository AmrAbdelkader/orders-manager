using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrdersManager.IoC
{
    public static class DomainLayer
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            //services.AddTransient<IOrderService, OrderService>();
            return services;
        }
    }
}
