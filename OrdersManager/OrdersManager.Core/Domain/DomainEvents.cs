using System;
using System.Reactive.Subjects;

namespace OrdersManager.Core.Domain
{
    public class DomainEvents<TDomainObject> where TDomainObject : IAggregateRoot
    {
        private Subject<TDomainObject> planeSpotted = new Subject<TDomainObject>();

        public IObservable<TDomainObject> PlaneSpotted
        {
            get { return planeSpotted; }
        }

        public void SpotPlane(TDomainObject Tobj)
        {
            this.planeSpotted.OnNext(Tobj);
        }
    }
}
