using OrdersManager.Core.Interfaces;

namespace eCommerce.InfrastructureLayer
{
    /// <summary>
    /// MemoryUnitOfWork class
    /// </summary>
    /// <seealso cref="OrdersManager.Core.Interfaces.IUnitOfWork" />
    public class MemoryUnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Commits this instance.
        /// </summary>
        public void Commit()
        {
            //commit
        }

        /// <summary>
        /// Rollbacks this instance.
        /// </summary>
        public void Rollback()
        {
            //rollback
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            //dispose
        }
    }
}
