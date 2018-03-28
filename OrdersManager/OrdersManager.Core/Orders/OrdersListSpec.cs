using OrdersManager.Core.Specification;
using System;
using System.Linq.Expressions;

namespace OrdersManager.Core.Orders
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="OrdersManager.Core.Specification.SpecificationBase{OrdersManager.Core.Orders.Order}" />
    public class OrdersListSpec : SpecificationBase<Order>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="OrdersListSpec"/> class.
        /// </summary>
        public OrdersListSpec()
        {
            
        }

        /// <summary>
        /// Gets the spec expression.
        /// </summary>
        /// <value>
        /// The spec expression.
        /// </value>
        public override Expression<Func<Order, bool>> SpecExpression
        {
            get
            {
                return order => true;
            }
        }
    }
}
