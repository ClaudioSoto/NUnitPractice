using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class CustomerControllerTests
    {

        // Test examples when the assert needs to check or compare the return of an object of type
        [Test]
        public void GetCustomer_IdIsZero_ResultNotFound()
        {
            //Arrange
            CustomerController customerObj = new CustomerController();

            //Act
            var result = customerObj.GetCustomer(0);

            //Assert
            //not found object
            Assert.That(result, Is.TypeOf<NotFound>());

            //notFound object or derivatives
            //Assert.That(result, Is.InstanceOf<NotFound>());
        }

        [Test]
        public void GetCustomer_DifferentFromZero_ResultOk()
        {
            //Arrange
            CustomerController customerObj = new CustomerController();

            //Act
            var result = customerObj.GetCustomer(1);

            //Assert
            //OK object
            Assert.That(result, Is.TypeOf<Ok>());

        }
    }
}
