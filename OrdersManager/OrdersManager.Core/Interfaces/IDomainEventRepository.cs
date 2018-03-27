using OrdersManager.Core.Domain;
using System.Collections.Generic;

namespace OrdersManager.Core.Interfaces
{
    /// <summary>
    /// IDomainEventRepository specifying the most common operation for persisting DomainEvents
    /// </summary>
    public interface IDomainEventRepository
    {
        /// <summary>
        /// Adds the specified domain event.
        /// </summary>
        /// <typeparam name="TDomainEvent">The type of the domain event.</typeparam>
        /// <param name="domainEvent">The domain event.</param>
        void Add<TDomainEvent>(TDomainEvent domainEvent) where TDomainEvent : DomainEvent;
        /// <summary>
        /// Finds all.
        /// </summary>
        /// <returns></returns>
        IEnumerable<DomainEventRecord> FindAll();
    }
}
