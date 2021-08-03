using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    class OrderServiceTests
    {
        [Test]
        public void PlaceOrder_WhenCalled_StoreTheOrder()
        {
            //Arrange
            //create the mock object
            var mockOrderService = new Mock<IStorage>();

            //create the order service object and pass the mock object
            var service = new OrderService(mockOrderService.Object);

            //Act
            //create a variable to store the object order to pass that to method PlaceOrder to test
            var order = new Order();
            service.PlaceOrder(order);

            //Assert
            //the mock object uses verify method to check is the order object is the same for return
            mockOrderService.Verify(mos => mos.Store(order));
        }
    }
}
