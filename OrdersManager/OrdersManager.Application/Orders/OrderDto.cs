using OrdersManager.Application.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text;

namespace OrdersManager.Application.Orders
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public IList<OrderItemOutputModel> Items { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }

    public class OrderItemOutputModel
    {
        public Guid ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
    }

}
