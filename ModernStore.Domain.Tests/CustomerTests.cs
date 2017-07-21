using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernStore.Domain.Entities;

namespace ModernStore.Domain.Tests
{
    [TestClass]
    public class CustomerTests
    {
        private User user = new User("andremorata", "andremorata");

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidFirstNameShouldReturnNotification()
        {
            var customer = new Customer(
                "", "Morata", "andremorata@gmail.com", user);
            Assert.IsFalse(customer.IsValid());
        }

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidLastNameShouldReturnNotification()
        {
            var customer = new Customer(
                "Andre", "", "andremorata@gmail.com", user);
            Assert.IsFalse(customer.IsValid());
        }

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidEmailShouldReturnNotification()
        {
            var customer = new Customer(
                "Andre", "Morata", "m", user);
            Assert.IsFalse(customer.IsValid());
        }
    }
}
