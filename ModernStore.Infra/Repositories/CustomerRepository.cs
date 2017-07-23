using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Infra.Contexts;
using System;
using System.Data.Entity;
using System.Linq;
using ModernStore.Domain.Commands.Results;
using System.Data.SqlClient;
using Dapper;
using ModernStore.Shared;

namespace ModernStore.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly ModernStoreDataContext _context;

        public CustomerRepository(ModernStoreDataContext context)
        {
            _context = context;
        }

        public bool DocumentExists(string document)
        {
            return _context.Customers.Any(
                    i => i.Document.Number == document);
        }

        public Customer Get(Guid id)
        {
            return _context.Customers
                .Include(i => i.User)
                .FirstOrDefault(i => i.Id == id);
        }

        public GetCustomerCommandResult Get(string username)
        {
            //return _context.Customers
            //    .Include(i => i.User)
            //    .AsNoTracking()
            //    .Select(x => new GetCustomerCommandResult()
            //    {
            //        Name = x.Name.ToString(),
            //        Document = x.Document.Number,
            //        Active = x.User.Active,
            //        Email = x.Email.Address,
            //        Username = x.User.Username,
            //        Password = x.User.Password
            //    })
            //    .FirstOrDefault(i => i.Username == username);

            using (var conn = new SqlConnection(Runtime.ConnectionString))
            {
                conn.Open();
                return conn
                    .Query<GetCustomerCommandResult>(
                        @"  SELECT * 
                            FROM GetCustomerInfoView 
                            WHERE Active = 1 and Username = @username",
                        new { username = username })
                    .FirstOrDefault();
            }
        }

        public Customer GetByDocumentNumber(string document)
        {
            return _context.Customers
                .Include(i => i.User)
                .AsNoTracking()
                .FirstOrDefault(i => i.Document.Number == document);
        }

        public Customer GetByUserId(Guid id)
        {
            return _context.Customers
                .Include(i => i.User)
                .AsNoTracking()
                .FirstOrDefault(i => i.User.Id == id);
        }

        public Customer GetByUsername(string username)
        {
            return _context
                .Customers
                .Include(i => i.User)
                .AsNoTracking()
                .FirstOrDefault(i => i.User.Username == username);
        }

        public void Save(Customer customer)
        {
            _context.Customers.Add(customer);
        }

        public void Update(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
        }
        
    }
}
