using System;
using System.Linq.Expressions;

namespace OrdersManager.Core.Specification
{
    /// <summary>
    /// ISpecification Interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISpecification<T>
    {
        /// <summary>
        /// Gets the spec expression.
        /// </summary>
        /// <value>
        /// The spec expression.
        /// </value>
        Expression<Func<T, bool>> SpecExpression { get; }

        /// <summary>
        /// Determines whether [is satisfied by] [the specified object].
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>
        ///   <c>true</c> if [is satisfied by] [the specified object]; otherwise, <c>false</c>.
        /// </returns>
        bool IsSatisfiedBy(T obj);
    }
}
