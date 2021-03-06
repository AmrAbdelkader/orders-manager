﻿using OrdersManager.Core.Domain;

namespace OrdersManager.Core.Orders
{
    /// <summary>
    /// OrderCreated Event arguments
    /// </summary>
    /// <seealso cref="OrdersManager.Core.Domain.DomainEvent" />
    public class OrderCreated : DomainEvent
    {
        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>
        /// The order.
        /// </value>
        public Order Order { get; set; }
    }
}
