using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class FizzBuzzTestsEjercicio1
    {
        private FizzBuzz _fizzObj;

        [SetUp]
        public void SetUp()
        {
            _fizzObj = new FizzBuzz();
        }

        [Test]
        public void GetOutput_ModuloFiveAndThree_ReturnFizzBuzz()
        {
            //Act
            var result = _fizzObj.GetOutput(15);

            //Assert
            Assert.That(result, Is.EqualTo("FizzBuzz"));
        }

        [Test]
        public void GetOutput_ModuloThreeOnly_ReturnFizz()
        {
            //Act
            var result = _fizzObj.GetOutput(3);

            //Assert
            Assert.That(result, Is.EqualTo("Fizz"));
        }

        [Test]
        public void GetOutput_ModuloFiveOnly_ReturnBuzz()
        {
            //Act
            var result = _fizzObj.GetOutput(5);

            //Assert
            Assert.That(result, Is.EqualTo("Buzz"));
        }

        public void GetOutput_ModuloFifferentFromZero_ReturnStrinNumber()
        {
            //Act
            var result = _fizzObj.GetOutput(1);

            //Assert
            Assert.That(result, Is.EqualTo("1"));
        }
    }
}
