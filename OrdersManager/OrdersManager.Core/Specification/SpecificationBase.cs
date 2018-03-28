using System;
using System.Linq.Expressions;

namespace OrdersManager.Core.Specification
{
    public abstract class SpecificationBase<T> : ISpecification<T>
    {
        /// <summary>
        /// The compiled expression
        /// </summary>
        private Func<T, bool> _compiledExpression;

        /// <summary>
        /// Gets the compiled expression.
        /// </summary>
        /// <value>
        /// The compiled expression.
        /// </value>
        private Func<T, bool> CompiledExpression
        {
            get { return _compiledExpression ?? (_compiledExpression = SpecExpression.Compile()); }
        }

        /// <summary>
        /// Gets the spec expression.
        /// </summary>
        /// <value>
        /// The spec expression.
        /// </value>
        public abstract Expression<Func<T, bool>> SpecExpression { get; }

        /// <summary>
        /// Determines whether [is satisfied by] [the specified object].
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>
        /// <c>true</c> if [is satisfied by] [the specified object]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsSatisfiedBy(T obj)
        {
            return CompiledExpression(obj);
        }
    }
}
