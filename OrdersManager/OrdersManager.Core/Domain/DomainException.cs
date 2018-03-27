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
        public DomainException()
        {
        }

        public DomainException(string message)
        : base(message)
        {
        }

        public DomainException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
