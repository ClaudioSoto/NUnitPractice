using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Mocking;

namespace TestNinja.Tests.OtherTests
{
    [TestFixture]
    class ProductTests
    {
        //CLASS OBJECT FOR TEST
        private Product _productClass;

        //HELPER OBJECT
        private Customer _customer;

        [SetUp]
        public void SetUp()
        {
            _productClass = new Product();
            _customer = new Customer();

            //INITIALIZATION FOR 2 TEST ONLY
            _productClass.ListPrice = 1;
        }

        [TearDown]
        public void TearDown()
        {
            _productClass = null;
            _customer = null;
        }

        [Test]
        public void GetPrice_IsGold_ReturnCalculation()
        {
            //Arrange
            _customer.IsGold = true;

            //Act
            var result = _productClass.GetPrice(_customer);

            //Asseert
            Assert.That(result, Is.EqualTo(0.7f));
        }

        [Test]
        public void GetPrice_IsNotGold_ReturnListPrice()
        {
            //Arrange
            _customer.IsGold = false;

            //Act
            var result = _productClass.GetPrice(_customer);

            //Asseert
            Assert.That(result, Is.EqualTo(1));
        }
    }
}
