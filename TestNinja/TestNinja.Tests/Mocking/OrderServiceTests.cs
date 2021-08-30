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
        public void saveOrder_SuccessStoredOrder_ReturnOrderId()
        {
            //Arrange
            var newOrder = new Order();
            var mockOrderService = new Mock<IOrderRepository>();
            mockOrderService.Setup(mos => mos.saveOrder(newOrder)).Returns(1);
            var orderServiceClassObject = new OrderService(mockOrderService.Object);

            //Act
            var result = orderServiceClassObject.PlaceOrder(newOrder);

            //Assert
            Assert.That(result, Is.EqualTo(1));

        }
    }
}
