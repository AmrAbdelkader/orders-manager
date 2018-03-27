using OrdersManager.Core.Specification;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace OrdersManager.Core.Orders
{
    public class OrdersListSpec : SpecificationBase<Order>
    {
        
        public OrdersListSpec()
        {
            
        }

        public override Expression<Func<Order, bool>> SpecExpression
        {
            get
            {
                return order => true;
            }
        }
    }
}
