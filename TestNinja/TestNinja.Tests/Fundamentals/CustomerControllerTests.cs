using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Fundamentals;

namespace TestNinja.Tests.Fundamentals
{
    [TestFixture]
    class CustomerControllerTests
    {
        [Test]
        public void GetCustomer_WhenIdIsZero_ReturnNotFound()
        {
            //Arrange
            var customerControllerClassObject = new CustomerController();

            //Act
            var result = customerControllerClassObject.GetCustomer(0);

            //Assert
            Assert.That(result, Is.InstanceOf<NotFound>());
        }

        [Test]
        public void GetCustomer_WhenIdIsNotZero_ReturnOk()
        {
            //Arrange
            var customerControllerClassObject = new CustomerController();

            //Act
            var result = customerControllerClassObject.GetCustomer(1);

            //Assert
            Assert.That(result, Is.InstanceOf<Ok>());
        }
    }
}
