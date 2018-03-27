using System;
using System.Linq.Expressions;

namespace OrdersManager.Core.Specification
{
    public class Not<T> : SpecificationBase<T>
    {
        /// <summary>
        /// The inner
        /// </summary>
        private readonly ISpecification<T> _inner;

        /// <summary>
        /// Initializes a new instance of the <see cref="Not{T}"/> class.
        /// </summary>
        /// <param name="inner">The inner.</param>
        public Not(ISpecification<T> inner)
        {
            _inner = inner;
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
                    Expression.Not(
                        Expression.Invoke(this._inner.SpecExpression, objParam)
                    ),
                    objParam
                );

                return newExpr;
            }
        }
    }
}
