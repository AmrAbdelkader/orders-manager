using OrdersManager.Core.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OrdersManager.Core.Orders
{
    /// <summary>
    /// Order Domain Object
    /// </summary>
    /// <seealso cref="OrdersManager.Core.Domain.IAggregateRoot" />
    public class Order : IAggregateRoot
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public virtual Guid Id { get; protected set; }
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>
        /// The customer identifier.
        /// </value>
        public virtual Guid CustomerId { get; protected set; }
        /// <summary>
        /// Gets or sets the created.
        /// </summary>
        /// <value>
        /// The created.
        /// </value>
        public virtual DateTime Created { get; protected set; }
        /// <summary>
        /// The order items
        /// </summary>
        private List<OrderItem> OrderItems = new List<OrderItem>();
        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public virtual ReadOnlyCollection<OrderItem> Items
        {
            get { return OrderItems.AsReadOnly(); }
        }

        /// <summary>
        /// Creates new order with the specified identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
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

            DomainEvents.Raise(new OrderCreated() { Order = order });

            return order;
        }

        /// <summary>
        /// Creates new order the specified user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public static Order Create(Guid userId)
        {
            return Create(Guid.NewGuid(), userId);
        }

        /// <summary>
        /// Adds the item.
        /// </summary>
        /// <param name="orderItem">The order item.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="DomainException">Item quantity should be greater than 0.</exception>
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

            DomainEvents.Raise(new OrderItemAdded() { _OrderItem = existingOrderItem });
        }

        /// <summary>
        /// Removes the item.
        /// </summary>
        /// <param name="ItemId">The item identifier.</param>
        /// <exception cref="DomainException"></exception>
        public virtual void RemoveItem(Guid ItemId)
        {
            var ItemToDelete = OrderItems.Find(i => i.ItemId == ItemId);
            if (ItemToDelete != null)
                OrderItems.Remove(ItemToDelete);
            else
                throw new DomainException($"Order {Id} does not have any items with Id {ItemId}");

            DomainEvents.Raise(new OrderItemRemoved() { _OrderItem =  ItemToDelete});
        }

        /// <summary>
        /// Clears all items in the order.
        /// </summary>
        public virtual void Clear()
        {
            OrderItems.Clear();
        }

    }
}
