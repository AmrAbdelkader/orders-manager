using Microsoft.Extensions.Configuration;
using OrdersManager.Client.Settings;
using Swagger;
using System;
using System.IO;

namespace OrdersManager.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();

            IConfigurationRoot configuration = builder.Build();

            var settings = new OrdersManagerClientSettings();
            configuration.Bind(settings);

            OrdersManagerAPI client = new OrdersManagerAPI(new Uri(settings.OrdersManagerAPIUrl));
            var result = client.ApiOrdersByIdGet(new Guid("2143d854-0982-44b5-9c5d-acfaf3b7236a"));


            Console.ReadLine();
        }
    }
}
