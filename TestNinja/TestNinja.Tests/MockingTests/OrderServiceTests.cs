using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Mocking;

namespace TestNinja.Tests.MockingTests
{
    [TestFixture]
    class OrderServiceTests
    {
        //CLASS OBJECT AND HELPER FOR TEST
        private Order _order;
        private OrderService _orderServiceClass;

        //MOCK OBJECTS
        private Mock<IStorage> _mockStorage;

        [SetUp]
        public void SetUp()
        {
            _order = new Order();
            _mockStorage = new Mock<IStorage>();
            _orderServiceClass = new OrderService(_mockStorage.Object);
        }

        [Test]
        [TestCase(1,1)]
        [TestCase(0,0)]
        [TestCase(-1,0)]
        public void PlaceOrder_TheOrderNotCreated_ReturnMinusOne(int id, int expected)
        {
            //arrange
            _mockStorage.Setup(ms => ms.Store(_order)).Returns(id);

            //Act
            var result = _orderServiceClass.PlaceOrder(_order);

            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
