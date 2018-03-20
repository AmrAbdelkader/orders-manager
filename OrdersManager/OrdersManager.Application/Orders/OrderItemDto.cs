using System;
using System.Collections.Generic;
using System.Text;

namespace OrdersManager.Application.Orders
{
    public class OrderItemDto
    {
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ItemId { get; set; }
        public int Quantity { get; set; }
    }
}
