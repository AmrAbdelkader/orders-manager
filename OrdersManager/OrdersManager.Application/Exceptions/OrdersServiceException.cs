using System;
using System.Collections.Generic;
using System.Text;

namespace OrdersManager.Application.Exceptions
{
    public class OrdersServiceException : Exception
    {
        public OrdersServiceException()
        {
        }

        public OrdersServiceException(string message)
        : base(message)
        {
        }

        public OrdersServiceException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
