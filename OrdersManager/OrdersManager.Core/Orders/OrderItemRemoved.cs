using OrdersManager.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrdersManager.Core.Orders
{
    public class OrderItemRemoved : DomainEvent
    {
        public OrderItem _OrderItem { get; set; }
    }
}
