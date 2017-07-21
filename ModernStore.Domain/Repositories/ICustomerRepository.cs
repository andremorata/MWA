using ModernStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Customer Get(Guid id);
        Customer GetByUserId(Guid id);

    }
}
