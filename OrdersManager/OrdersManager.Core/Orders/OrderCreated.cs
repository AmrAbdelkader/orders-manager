using OrdersManager.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrdersManager.Core.Orders
{
    public class OrderCreated : DomainEvent
    {
        public Order Order { get; set; }
    }
}
