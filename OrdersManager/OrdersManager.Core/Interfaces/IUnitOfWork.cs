using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrdersManager.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Rollback();
    }
}
