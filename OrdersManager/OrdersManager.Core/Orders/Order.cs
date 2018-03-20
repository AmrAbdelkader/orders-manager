using OrdersManager.Core.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using OrdersManager.Core.Items;
using OrdersManager.Core.Users;

namespace OrdersManager.Core.Orders
{
    public class Order : IAggregateRoot
    {
        public virtual Guid Id { get; protected set; }
        public virtual Guid CustomerId { get; protected set; }

        private List<OrderItem> OrderItems = new List<OrderItem>();

        public virtual ReadOnlyCollection<OrderItem> Items
        {
            get { return OrderItems.AsReadOnly(); }
        }

        public static Order Create(User user)
        {
            if (user == null)
                throw new ArgumentNullException("customer");

            Order order = new Order
            {
                Id = Guid.NewGuid(),
                CustomerId = user.Id
            };
            
            //DomainEvents.Raise<OrderCreated>(new OrderCreated() { Order = order });

            return order;
        }

        public virtual void AddItem(OrderItem orderItem)
        {
            if (orderItem == null)
                throw new ArgumentNullException();

            //DomainEvents.Raise<ProductAddedCart>(new ProductAddedCart() { CartProduct = cartProduct });

            this.OrderItems.Add(orderItem);
        }
    }
}
