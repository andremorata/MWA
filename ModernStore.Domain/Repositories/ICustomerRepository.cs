using ModernStore.Domain.Commands.Results;
using ModernStore.Domain.Entities;
using System;

namespace ModernStore.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Customer Get(Guid id);
        Customer GetByUsername(string username);
        Customer GetByDocumentNumber(string document);
        GetCustomerCommandResult Get(string username);
        Customer GetByUserId(Guid id);
        void Save(Customer customer);
        void Update(Customer customer);
        bool DocumentExists(string document);
    }
}
