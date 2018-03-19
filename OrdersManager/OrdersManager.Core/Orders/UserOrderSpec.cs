using OrdersManager.Core.Specification;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace OrdersManager.Core.Orders
{
    public class UserOrderSpec : SpecificationBase<Order>
    {
        private readonly Guid customerId;

        public UserOrderSpec(Guid customerId)
        {
            this.customerId = customerId;
        }

        public override Expression<Func<Order, bool>> SpecExpression
        {
            get
            {
                return cart => cart.CustomerId == this.customerId;
            }
        }

    }
}
