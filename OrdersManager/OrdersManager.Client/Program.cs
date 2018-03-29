using Swagger;
using System;

namespace OrdersManager.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            OrdersManagerAPI client = new OrdersManagerAPI(new Uri("http://localhost:58483"));
            var result = client.ApiOrdersByIdGet(new Guid("2143d854-0982-44b5-9c5d-acfaf3b7236a"));
            Console.ReadLine();
        }
    }
}
