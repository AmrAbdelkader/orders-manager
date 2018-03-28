using OrdersManager.Core.Domain;

namespace OrdersManager.Core.Items
{
    /// <summary>
    /// ItemCreated event's data
    /// </summary>
    /// <seealso cref="OrdersManager.Core.Domain.DomainEvent" />
    public class ItemCreated : DomainEvent
    {
        /// <summary>
        /// Gets or sets the item.
        /// </summary>
        /// <value>
        /// The item.
        /// </value>
        public Item Item { get; set; }
    }
}
