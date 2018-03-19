using OrdersManager.Core.Interfaces;

namespace eCommerce.InfrastructureLayer
{
    public class MemoryUnitOfWork : IUnitOfWork
    {
        public void Commit()
        {
            //commit
        }

        public void Rollback()
        {
            //rollback
        }

        public void Dispose()
        {
            //dispose
        }
    }
}
