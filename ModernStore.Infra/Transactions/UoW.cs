using ModernStore.Infra.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Infra.Transactions
{
    public class UoW : IUoW
    {
        private readonly ModernStoreDataContext _context;

        public UoW(ModernStoreDataContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            // Do nothing :-)
        }
    }
}
