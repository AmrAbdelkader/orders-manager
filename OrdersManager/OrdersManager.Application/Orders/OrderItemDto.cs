using System;
using System.Collections.Generic;
using System.Text;

namespace OrdersManager.Application.Orders
{
    public class OrderItemDto
    {
        public Guid ItemId { get; set; }
        public int Quantity { get; set; }
    }
}
