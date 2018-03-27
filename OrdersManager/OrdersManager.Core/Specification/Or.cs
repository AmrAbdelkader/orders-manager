using System;
using System.Linq.Expressions;

namespace OrdersManager.Core.Specification
{
    public class Or<T> : SpecificationBase<T>
    {
        /// <summary>
        /// The left
        /// </summary>
        ISpecification<T> left;
        
        /// <summary>
        /// The right
        /// </summary>
        ISpecification<T> right;

        /// <summary>
        /// Initializes a new instance of the <see cref="Or{T}" /> class.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        public Or(ISpecification<T> left, ISpecification<T> right)
        {
            this.left = left;
            this.right = right;
        }

        /// <summary>
        /// Gets the spec expression.
        /// </summary>
        /// <value>
        /// The spec expression.
        /// </value>
        public override Expression<Func<T, bool>> SpecExpression
        {
            get
            {
                var objParam = Expression.Parameter(typeof(T), "obj");

                var newExpr = Expression.Lambda<Func<T, bool>>(
                    Expression.OrElse(
                        Expression.Invoke(left.SpecExpression, objParam),
                        Expression.Invoke(right.SpecExpression, objParam)
                    ),
                    objParam
                );

                return newExpr;
            }
        }
    }
}
