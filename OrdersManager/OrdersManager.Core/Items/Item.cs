using OrdersManager.Core.Domain;
using System;

namespace OrdersManager.Core.Items
{
    /// <summary>
    /// Item Domain Object
    /// </summary>
    /// <seealso cref="OrdersManager.Core.Domain.IAggregateRoot" />
    public class Item : IAggregateRoot
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public virtual Guid Id { get; protected set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public virtual string Name { get; protected set; }
        /// <summary>
        /// Gets or sets the created.
        /// </summary>
        /// <value>
        /// The created.
        /// </value>
        public virtual DateTime Created { get; protected set; }
        /// <summary>
        /// Gets or sets the modified.
        /// </summary>
        /// <value>
        /// The modified.
        /// </value>
        public virtual DateTime Modified { get; protected set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Item"/> is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if active; otherwise, <c>false</c>.
        /// </value>
        public virtual bool Active { get; protected set; }
        //public virtual int Quantity { get; protected set; }
        /// <summary>
        /// Gets or sets the cost.
        /// </summary>
        /// <value>
        /// The cost.
        /// </value>
        public virtual double Price { get; protected set; }

        /// <summary>
        /// Creates the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="cost">The cost.</param>
        /// <returns></returns>
        public static Item Create(string name, double cost)
        {
            return Create(Guid.NewGuid(), name, cost);
        }

        /// <summary>
        /// Creates the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="cost">The cost.</param>
        /// <returns></returns>
        public static Item Create(Guid id, string name, double cost)
        {
            Item item = new Item()
            {
                Id = id,
                Name = name,
                Created = DateTime.Now,
                Modified = DateTime.Now,
                Active = true,
                Price = cost
            };

            DomainEvents.Raise<ItemCreated>(new ItemCreated() { Item = item });

            return item;
        }
    }
}