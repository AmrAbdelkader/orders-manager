using OrdersManager.Core.Items;
using System;

namespace OrdersManager.Core.Orders
{
    /// <summary>
    /// OrderItem Domain objet
    /// </summary>
    public class OrderItem
    {
        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>
        /// The order identifier.
        /// </value>
        public virtual Guid OrderId { get; set; }
        /// <summary>
        /// Gets or sets the item identifier.
        /// </summary>
        /// <value>
        /// The item identifier.
        /// </value>
        public virtual Guid ItemId { get; set; }
        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        public virtual int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the cost.
        /// </summary>
        /// <value>
        /// The cost.
        /// </value>
        public double Cost { get; set; }

        /// <summary>
        /// Gets or sets the created.
        /// </summary>
        /// <value>
        /// The created.
        /// </value>
        public virtual DateTime Created { get; set; }
        /// <summary>
        /// Gets or sets the updated.
        /// </summary>
        /// <value>
        /// The updated.
        /// </value>
        public virtual DateTime Updated { get; set; }

        /// <summary>
        /// Creates the specified order.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <param name="item">The item.</param>
        /// <param name="quantity">The quantity.</param>
        /// <returns></returns>
        public static OrderItem Create(Order order, Item item, int quantity)
        {
            OrderItem orderItem = new OrderItem()
            {
                OrderId = order.Id,
                ItemId = item.Id,
                Quantity = quantity,
                Cost = item.Price,
                Created = DateTime.Now
            };

            return orderItem;
        }
    }
}
