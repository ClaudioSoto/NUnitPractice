using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Fundamentals;

namespace TestNinja.Tests.Fundamentals
{
    [TestFixture]
    class FizzBuzzTests
    {
        private FizzBuzz _fizzBuzzClassObject;

        [SetUp]
        public void SetUp()
        {
            _fizzBuzzClassObject = new FizzBuzz();
        }

        [TearDown]
        public void TearDown()
        {
            _fizzBuzzClassObject = null;
        }

        [Test]
        [TestCase(15,"FizzBuzz")]
        [TestCase(3, "Fizz")]
        [TestCase(5, "Buzz")]
        [TestCase(1, "1")]
        public void GetOutput_ModuloBetweeThreeAndFiveIsZero_ReturnFizzBuzz(int number, string expected)
        {
            //Arrange - Act
            var result = _fizzBuzzClassObject.GetOutput(number);

            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
