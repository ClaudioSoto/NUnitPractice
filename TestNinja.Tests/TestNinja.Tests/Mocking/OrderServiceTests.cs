using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Mocking;

namespace TestNinja.Tests.Mocking
{
    [TestFixture]
    class OrderServiceTests
    {
        
        [Test]
        public void PlaceOrder_WhenCalled_StoreOrder()
        {
            //Arrange
            var mockStorage = new Mock<IStorage>();
            var orderService = new OrderService(mockStorage.Object);

            //Act
            var newOrder = new Order();
            orderService.PlaceOrder(newOrder);

            //Assert
            mockStorage.Verify(ms => ms.Store(newOrder));

        }





    }
}
