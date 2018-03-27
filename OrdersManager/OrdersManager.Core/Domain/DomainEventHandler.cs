using OrdersManager.Core.Interfaces;

namespace OrdersManager.Core.Domain
{
    public class DomainEventHandler<TDomainEvent> : IHandles<TDomainEvent>
        where TDomainEvent : DomainEvent
    {
        IDomainEventRepository domainEventRepository;

        public DomainEventHandler(IDomainEventRepository domainEventRepository)
        {
            this.domainEventRepository = domainEventRepository;
        }

        public void Handle(TDomainEvent domainEvent)
        {
            this.domainEventRepository.Add(domainEvent);
        }
    }
}
