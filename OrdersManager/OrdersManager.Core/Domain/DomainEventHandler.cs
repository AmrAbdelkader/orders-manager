using OrdersManager.Core.Interfaces;

namespace OrdersManager.Core.Domain
{
    /// <summary>
    /// DomainEventHandler class to handle Domain events
    /// </summary>
    /// <typeparam name="TDomainEvent">The type of the domain event.</typeparam>
    /// <seealso cref="OrdersManager.Core.Domain.IHandles{TDomainEvent}" />
    public class DomainEventHandler<TDomainEvent> : IHandles<TDomainEvent>
        where TDomainEvent : DomainEvent
    {
        IDomainEventRepository domainEventRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DomainEventHandler{TDomainEvent}"/> class.
        /// </summary>
        /// <param name="domainEventRepository">The domain event repository.</param>
        public DomainEventHandler(IDomainEventRepository domainEventRepository)
        {
            this.domainEventRepository = domainEventRepository;
        }

        /// <summary>
        /// Handles the specified domain event.
        /// </summary>
        /// <param name="domainEvent">The domain event.</param>
        public void Handle(TDomainEvent domainEvent)
        {
            this.domainEventRepository.Add(domainEvent);
        }
    }
}
