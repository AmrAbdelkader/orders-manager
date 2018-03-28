using System;

namespace OrdersManager.Core.Domain
{
    /// <summary>
    /// A custom Business domain exception that should be thrown whenever certain 
    /// business scenario was violated
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class DomainException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainException"/> class.
        /// </summary>
        public DomainException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DomainException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public DomainException(string message)
        : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DomainException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public DomainException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
