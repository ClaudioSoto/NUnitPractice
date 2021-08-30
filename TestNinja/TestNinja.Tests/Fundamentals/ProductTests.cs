using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Mocking;

namespace TestNinja.Tests.Fundamentals
{
    [TestFixture]
    class ProductTests
    {
        private Product _productClassObject;
        private Customer _customerAuxObject;

        [SetUp]
        public void SetUp()
        {
            _productClassObject = new Product();
            _customerAuxObject = new Customer();

            _productClassObject.ListPrice = 1;
        }

        [TearDown]
        public void TearDown()
        {
            _productClassObject = null;
            _customerAuxObject = null;
        }

        [Test]
        [TestCase(true,0.7f)]
        [TestCase(false, 1)]
        public void GetPrice_WhenCalled_ReturnCalculation(bool isGold, float expectedValue)
        {
            //Arrange
            _customerAuxObject.IsGold = isGold;

            //Act
            var result = _productClassObject.GetPrice(_customerAuxObject);

            //Assert
            Assert.That(result, Is.EqualTo(expectedValue));
        }
    }
}
