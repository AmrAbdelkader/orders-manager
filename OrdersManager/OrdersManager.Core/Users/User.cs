using OrdersManager.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrdersManager.Core.Users
{
    public class User : IAggregateRoot
    {
        public virtual Guid Id { get; protected set; }
        public virtual string FirstName { get; protected set; }
        public virtual string LastName { get; protected set; }
        public virtual string Email { get; protected set; }
        public virtual string Password { get; protected set; }

        public static User Create(string firstname, string lastname, string email)
        {
            return Create(Guid.NewGuid(), firstname, lastname, email);
        }

        public static User Create(Guid id, string firstname, string lastname, string email)
        {
            if (string.IsNullOrEmpty(firstname))
                throw new ArgumentNullException("firstname");

            if (string.IsNullOrEmpty(lastname))
                throw new ArgumentNullException("lastname");

            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException("email");
            
            User customer = new User()
            {
                Id = id,
                FirstName = firstname,
                LastName = lastname,
                Email = email
            };
            DomainEvents.Raise<UserCreated>(new UserCreated() { _User = customer });

            return customer;
        }
    }
}
