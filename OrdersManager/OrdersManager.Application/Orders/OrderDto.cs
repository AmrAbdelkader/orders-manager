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
        public Guid CustomerId { get; set; }
    }
}
