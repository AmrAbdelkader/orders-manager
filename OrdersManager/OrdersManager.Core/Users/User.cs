using OrdersManager.Core.Domain;
using System;

namespace OrdersManager.Core.Users
{
    /// <summary>
    /// User class respresents users data
    /// </summary>
    /// <seealso cref="OrdersManager.Core.Domain.IAggregateRoot" />
    public class User : IAggregateRoot
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public virtual Guid Id { get; protected set; }
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public virtual string FirstName { get; protected set; }
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public virtual string LastName { get; protected set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public virtual string Email { get; protected set; }
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public virtual string Password { get; protected set; }

        /// <summary>
        /// Creates the specified firstname.
        /// </summary>
        /// <param name="firstname">The firstname.</param>
        /// <param name="lastname">The lastname.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public static User Create(string firstname, string lastname, string email)
        {
            return Create(Guid.NewGuid(), firstname, lastname, email);
        }

        /// <summary>
        /// Creates the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="firstname">The firstname.</param>
        /// <param name="lastname">The lastname.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// firstname
        /// or
        /// lastname
        /// or
        /// email
        /// </exception>
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
