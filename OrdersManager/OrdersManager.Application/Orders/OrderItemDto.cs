﻿using System;

namespace OrdersManager.Application.Orders
{
    /// <summary>
    /// OrderItemDTO OrderItem Data transfer object
    /// </summary>
    public class OrderItemDto
    {
        /// <summary>
        /// Gets or sets the item identifier.
        /// </summary>
        /// <value>
        /// The item identifier.
        /// </value>
        public Guid ItemId { get; set; }
        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        public int Quantity { get; set; }
    }
}
