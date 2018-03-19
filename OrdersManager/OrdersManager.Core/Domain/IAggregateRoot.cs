using System;

namespace OrdersManager.Core.Domain
{
    public interface IAggregateRoot
    {
        Guid Id { get; }
    }
}
