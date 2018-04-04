using System;
using System.ComponentModel.DataAnnotations;

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
        [Required]
        public Guid ItemId { get; set; }
        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        [Required]
        public int Quantity { get; set; }
    }
}
