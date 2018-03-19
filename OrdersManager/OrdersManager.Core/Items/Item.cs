using OrdersManager.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrdersManager.Core.Items
{
    public class Item : IAggregateRoot
    {
        public virtual Guid Id { get; protected set; }
        public virtual string Name { get; protected set; }
        public virtual DateTime Created { get; protected set; }
        public virtual DateTime Modified { get; protected set; }
        public virtual bool Active { get; protected set; }
        public virtual int Quantity { get; protected set; }
        public virtual decimal Cost { get; protected set; }

        public static Item Create(string name, int quantity, decimal cost)
        {
            return Create(Guid.NewGuid(), name, quantity, cost);
        }

        public static Item Create(Guid id, string name, int quantity, decimal cost)
        {
            Item product = new Item()
            {
                Id = id,
                Name = name,
                Quantity = quantity,
                Created = DateTime.Now,
                Modified = DateTime.Now,
                Active = true,
                Cost = cost
            };

            //DomainEvents.Raise<ProductCreated>(new ProductCreated() { Product = product });

            return product;
        }
    }
}