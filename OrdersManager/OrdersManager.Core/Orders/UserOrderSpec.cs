using OrdersManager.Core.Specification;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace OrdersManager.Core.Orders
{
    public class OrderSpec : SpecificationBase<Order>
    {
        private readonly Guid orderId;

        public OrderSpec(Guid orderId)
        {
            this.orderId = orderId;
        }

        public override Expression<Func<Order, bool>> SpecExpression
        {
            get
            {
                return order => order.Id == this.orderId;
            }
        }

    }
}
