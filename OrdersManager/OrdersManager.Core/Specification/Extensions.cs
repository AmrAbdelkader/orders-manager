namespace OrdersManager.Core.Specification
{
    /// <summary>
    /// Specification Extension methods needed
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Ands the specified right.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns></returns>
        public static ISpecification<T> And<T>(this ISpecification<T> left, ISpecification<T> right)
        {
            return new And<T>(left, right);
        }

        /// <summary>
        /// Ors the specified right.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns></returns>
        public static ISpecification<T> Or<T>(this ISpecification<T> left, ISpecification<T> right)
        {
            return new Or<T>(left, right);
        }

        /// <summary>
        /// Negates the specified inner.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inner">The inner.</param>
        /// <returns></returns>
        public static ISpecification<T> Negate<T>(this ISpecification<T> inner)
        {
            return new Not<T>(inner);
        }
    }
}
