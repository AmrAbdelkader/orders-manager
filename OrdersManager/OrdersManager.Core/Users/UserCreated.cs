using OrdersManager.Core.Domain;

namespace OrdersManager.Core.Users
{
    /// <summary>
    /// UserCreated event args
    /// </summary>
    /// <seealso cref="OrdersManager.Core.Domain.DomainEvent" />
    public class UserCreated : DomainEvent
    {
        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public User _User { get; set; }
    }
}
