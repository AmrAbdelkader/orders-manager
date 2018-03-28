using OrdersManager.Core.Specification;
using System;
using System.Linq.Expressions;

namespace OrdersManager.Core.Orders
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="OrdersManager.Core.Specification.SpecificationBase{OrdersManager.Core.Orders.Order}" />
    public class OrderSpec : SpecificationBase<Order>
    {
        /// <summary>
        /// The order identifier
        /// </summary>
        private readonly Guid orderId;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderSpec"/> class.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        public OrderSpec(Guid orderId)
        {
            this.orderId = orderId;
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
                return order => order.Id == this.orderId;
            }
        }

    }
}
