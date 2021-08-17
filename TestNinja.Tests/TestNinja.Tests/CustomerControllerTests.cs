using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Fundamentals;

namespace TestNinja.Tests
{
    [TestFixture]
    class CustomerControllerTests
    {
        private CustomerController _customer;

        [SetUp]
        public void SetUp()
        {
            _customer = new CustomerController();
        }

        [TearDown]
        public void TearDown()
        {
            _customer = null;
        }

        [Test]
        public void GetCustomer_IdIsZero_ReturnNotFound()
        {
            //Arrange - Act
            var result = _customer.GetCustomer(0);

            //Assert
            Assert.That(result, Is.TypeOf<NotFound>());
        }

        [Test]
        public void GetCustomer_IdIsDifferentFromZero_ReturnOk()
        {
            //Arrange - Act
            var result = _customer.GetCustomer(1);

            //Assert
            Assert.That(result, Is.TypeOf<Ok>());
        }

    }
}
