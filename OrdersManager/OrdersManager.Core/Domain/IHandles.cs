namespace OrdersManager.Core.Domain
{
    /// <summary>
    /// IHandles interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IHandles<T> where T : DomainEvent
    {
        /// <summary>
        /// Handles the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        void Handle(T args);
    }
}
