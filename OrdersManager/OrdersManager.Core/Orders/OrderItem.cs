using OrdersManager.Core.Items;
using OrdersManager.Core.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrdersManager.Core.Orders
{
    public class OrderItem
    {
        public virtual Guid CartId { get; protected set; }
        public virtual Guid CustomerId { get; protected set; }
        public virtual int Quantity { get; protected set; }
        public virtual Guid ItemId { get; protected set; }
        public virtual DateTime Created { get; protected set; }
        public virtual decimal Cost { get; protected set; }

        public static OrderItem Create(User user, Order order, Item item, int quantity)
        {
            //if (order == null)
            //    throw new ArgumentNullException("cart");

            //if (item == null)
            //    throw new ArgumentNullException("product");

            OrderItem orderItem = new OrderItem()
            {
                CustomerId = user.Id,
                CartId = order.Id,
                ItemId = item.Id,
                Quantity = quantity,
                Created = DateTime.Now,
                Cost = item.Cost
            };

            return orderItem;
        }
    }
}
