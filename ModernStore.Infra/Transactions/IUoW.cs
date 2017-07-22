using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Infra.Transactions
{
    public interface IUoW
    {
        void Commit();
        void Rollback();
    }
}
