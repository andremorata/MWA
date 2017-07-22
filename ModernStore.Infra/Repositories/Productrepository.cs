using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Infra.Contexts;
using System;
using System.Linq;

namespace ModernStore.Infra.Repositories
{
    public class Productrepository : IProductRepository
    {
        private readonly ModernStoreDataContext _context;

        public Productrepository(ModernStoreDataContext context)
        {
            _context = context;
        }

        public Product Get(Guid id)
        {
            return _context
                .Products
                .AsNoTracking()
                .FirstOrDefault(i => i.Id == id);
        }
        
    }
}
