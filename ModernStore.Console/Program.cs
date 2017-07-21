using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModernStore.Domain.Entities;
using ModernStore.Domain.ValueObjects;
using ModernStore.Domain.Repositories;
using ModernStore.Domain.Commands;
using ModernStore.Domain.CommandHandlers;

namespace ModernStore
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = new RegisterOrderCommand
            {
                Customer = Guid.NewGuid(),
                DeliveryFee = 10,
                Discount = 5,
                Items = new List<RegisterOrderItemCommand>
                {
                    new RegisterOrderItemCommand() { Product = Guid.NewGuid(), Quantity = 2 },
                    new RegisterOrderItemCommand() { Product = Guid.NewGuid(), Quantity = 5 }
                }
            };

            GenereateOrder(
                new FakeCustomerRepository(),
                new FakeProductRepository(),
                new FakeOrderRepository(),
                command);

            Console.ReadKey();
        }

        private static void GenereateOrder(
            ICustomerRepository customerRepository,
            IProductRepository productRepository,
            IOrderRepository orderRepository,
            RegisterOrderCommand command)
        {

            var handler = new OrderCommandHandler(
                customerRepository,
                productRepository,
                orderRepository);

            handler.Handle(command);

            if (handler.IsValid())
                Console.WriteLine("Pedido cadastrado com sucesso");
            
        }
    }

    public class FakeProductRepository : IProductRepository
    {
        public Product Get(Guid id)
        {
            return new Product(
                "Mouse", 299, 5, "mouse.png");
        }

        public IEnumerable<Product> Get(IEnumerable<Guid> ids)
        {
            throw new NotImplementedException();
        }
    }

    public class FakeCustomerRepository : ICustomerRepository
    {
        public Customer Get(Guid id)
        {
            return null;
        }

        public Customer GetByUserId(Guid id)
        {
            return new Customer(
                new Name("Andre", "Morata"),
                new Email("andremorata@gmail.com"),
                new Document("30260406813"),
                new User("andremorata", "andremorata"));
        }
    }

    public class FakeOrderRepository : IOrderRepository
    {
        public void Save(Order order)
        {
            
        }
    }
}
