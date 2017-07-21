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
            var Customer = new Customer(
                "Andre",
                "Morata",
                "andremorata@gmail.com",
                user
            );

            Customer.Update("Andre Luis", "Morata Fernandes", new DateTime(1983, 9, 13));
            
            if (Customer.Notifications.Count > 0)
                foreach (var item in Customer.Notifications)
                    Console.WriteLine(item.Message);

            Console.WriteLine(Customer.ToString());
            Console.ReadKey();
        }
    }
}
