﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OrdersManager.Core.Domain
{
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
