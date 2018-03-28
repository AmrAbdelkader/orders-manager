using OrdersManager.Core.Domain;

namespace OrdersManager.Core.Orders
{
    /// <summary>
    /// OrderItemAdded event aruments
    /// </summary>
    /// <seealso cref="OrdersManager.Core.Domain.DomainEvent" />
    public class OrderItemAdded : DomainEvent
    {
        /// <summary>
        /// Gets or sets the order item.
        /// </summary>
        /// <value>
        /// The order item.
        /// </value>
        public OrderItem _OrderItem { get; set; }
    }
}
