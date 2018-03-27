using System;

namespace OrdersManager.Core.Domain
{
    /// <summary>
    /// IAggregateRoot interface
    /// </summary>
    public interface IAggregateRoot
    {
        Guid Id { get; }
    }
}
