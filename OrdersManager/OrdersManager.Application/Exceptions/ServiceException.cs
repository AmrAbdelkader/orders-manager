using System;

namespace OrdersManager.Application.Exceptions
{
    /// <summary>
    /// Service Layer exception
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class ServiceException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceException"/> class.
        /// </summary>
        public ServiceException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ServiceException(string message)
        : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public ServiceException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
