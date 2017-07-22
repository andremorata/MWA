﻿using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Infra.Contexts;
using System;
using System.Linq;
using ModernStore.Domain.Commands.Results;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;

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

        public IEnumerable<GetProductListCommandResult> Get()
        {
            using (var conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Database=ModernStoreConnectionString;Integrated Security=SSPI;"))
            {
                conn.Open();
                return conn
                    .Query<GetProductListCommandResult>(@"SELECT Id, Title, Price, Image FROM Product");
            }
        }
    }
}
