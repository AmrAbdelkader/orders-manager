using OrdersManager.Core.Domain;

namespace OrdersManager.Core.Users
{
    public class UserCreated : DomainEvent
    {
        public User _User { get; set; }
    }
}
