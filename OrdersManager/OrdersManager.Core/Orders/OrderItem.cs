using OrdersManager.Core.Items;
using OrdersManager.Core.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrdersManager.Core.Orders
{
    public class OrderItem : IEquatable<OrderItem>
    {
        public virtual Guid OrderId { get; set; }
        public virtual Guid ItemId { get; set; }
        public virtual int Quantity { get; set; }
        public virtual decimal Cost { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime Updated { get; set; }

        public static OrderItem Create(Order order, Item item, int quantity)
        {
            //if (order == null)
            //    throw new ArgumentNullException("cart");

            //if (item == null)
            //    throw new ArgumentNullException("product");

            OrderItem orderItem = new OrderItem()
            {
                OrderId = order.Id,
                ItemId = item.Id,
                Quantity = quantity,
                Created = DateTime.Now,
                Cost = item.Cost
            };

            return orderItem;
        }

        public bool Equals(OrderItem other)
        {
            return this.ItemId == other.ItemId && this.OrderId == other.OrderId;
        }
    }
}
