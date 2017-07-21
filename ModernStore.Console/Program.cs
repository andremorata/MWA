using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModernStore.Domain.Entities;

namespace ModernStore
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new User("andremorata", "andremorata");
            var customer = new Customer(
                "Andre",
                "Morata",
                "andremorata@gmail.com",
                user
            );

            var mouse = new Product("Mouse", 299, 50, "mouse.png");
            var mousepad = new Product("MousePad", 50, 50, "mousepad.png");
            
            var order = new Order(customer, 5, 10);
            order.AddItem(new OrderItem(mouse, 2));
            order.AddItem(new OrderItem(mousepad, 2));
            
            Console.WriteLine($"Nro Pedido: {order.Number}");
            Console.WriteLine($"Data: {order.CreateDate :dd/MM/yyyy}");
            Console.WriteLine($"Desconto: {order.Discount}");
            Console.WriteLine($"Taxa de Entrega: {order.DeliveryFee}");
            Console.WriteLine($"Subtotal: {order.SubTotal()}");
            Console.WriteLine($"Total: {order.Total()}");
            Console.WriteLine($"Cliente: {customer.FirstName} {customer.LastName}");
            
            Console.ReadKey();
        }
    }
}
