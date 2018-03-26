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
        public virtual DateTime Created { get; protected set; }

        private List<OrderItem> OrderItems = new List<OrderItem>();

        public virtual ReadOnlyCollection<OrderItem> Items
        {
            get { return OrderItems.AsReadOnly(); }
        }

        public static Order Create(Guid Id, Guid userId)
        {
            //if (user == null)
            //    throw new ArgumentNullException("customer");

            Order order = new Order
            {
                Id = Id,
                CustomerId = userId,
                Created = DateTime.Now
            };

            //DomainEvents.Raise<OrderCreated>(new OrderCreated() { Order = order });

            return order;
        }

        public static Order Create(Guid userId)
        {
            return Create(Guid.NewGuid(), userId);
        }

        public virtual void AddItem(OrderItem orderItem)
        {
            if (orderItem == null)
                throw new ArgumentNullException();

            if (orderItem.Quantity <= 0)
                throw new DomainException("Item quantity should be greater than 0.");

            /// if the new order item is already exists in the order then update its quantity, otherwise add it in the order.
            var existingOrderItem = OrderItems.Find(i => i.ItemId == orderItem.ItemId);

            if (existingOrderItem != null)
                existingOrderItem.Quantity = orderItem.Quantity;
            else
                OrderItems.Add(orderItem);

            //DomainEvents.Raise<ProductAddedCart>(new ProductAddedCart() { CartProduct = cartProduct });
        }

        public virtual void RemoveItem(Guid ItemId)
        {
            var ItemToDelete = OrderItems.Find(i => i.ItemId == ItemId);
            if (ItemToDelete != null)
                OrderItems.Remove(ItemToDelete);
            else
                throw new DomainException($"Order {Id} does not have any items with Id {ItemId}");
        }

        public virtual void Clear()
        {
            OrderItems.Clear();
        }

    }
}
