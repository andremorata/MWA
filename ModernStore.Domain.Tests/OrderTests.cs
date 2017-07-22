using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernStore.Domain.Entities;

namespace ModernStore.Domain.Tests
{
    [TestClass]
    public class OrderTests
    {
        //private readonly Customer _customer = 
        //    new Customer("Andre", "Morata", "andremorata@gmail.com",
        //        new User("andremorata", "andremorata")
        //    );

        //[TestMethod]
        //[TestCategory("Order - New Order")]
        //public void GivenAnOutOfStockProductItShouldReturnAnError()
        //{
        //    var mouse = new Product("Mouse", 299, 0, "mouse.png");

        //    var order = new Order(_customer, 5, 10);
        //    order.AddItem(new OrderItem(mouse, 2));

        //    Assert.IsFalse(order.IsValid());
        //}

        //[TestMethod]
        //[TestCategory("Order - New Order")]
        //public void GivenAnInStockProdctItShouldDecreaseQuantityOnHand()
        //{
        //    var mouse = new Product("Mouse", 299, 2, "mouse.png");

        //    var order = new Order(_customer, 5, 10);
        //    order.AddItem(new OrderItem(mouse, 2));

        //    Assert.IsTrue(mouse.QuantityOnHand == 0);
        //}

        //[TestMethod]
        //[TestCategory("Order - New Order")]
        //public void GivenAValidOrderItShouldReturnCorrectTotal()
        //{
        //    var mouse = new Product("Mouse", 300, 2, "mouse.png");

        //    var order = new Order(_customer, 5, 10);
        //    order.AddItem(new OrderItem(mouse, 1));

        //    Assert.IsTrue(order.Total() == 295);
        //}
    }
}
