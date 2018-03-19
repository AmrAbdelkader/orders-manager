using OrdersManager.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrdersManager.Core.Orders
{
    public class OrderCreated : DomainEvent
    {
        public Order Order { get; set; }

        public override void Flatten()
        {
            throw new NotImplementedException();
        }
        

        //public override void Flatten()
        //{
        //    this.Args.Add("CustomerId", this.Cart.CustomerId);
        //    this.Args.Add("CartId", this.Cart.Id);
        //}
    }
}
