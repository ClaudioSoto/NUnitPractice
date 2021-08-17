using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Fundamentals;

namespace TestNinja.Tests
{
    [TestFixture]
    class FizzBuzzTests
    {
        private FizzBuzz _fizzBuzz;

        [SetUp]
        public void SetUp()
        {
            _fizzBuzz = new FizzBuzz();
        }

        [Test]
        [TestCase("FizzBuzz",15)]
        [TestCase("Fizz",3)]
        [TestCase("Buzz",5)]
        [TestCase("1",1)]
        public void FizzBuzz_WhenCalled_ReturntestCaseResult(string expected, int number)
        {
            //Arrange - Act
            var result = _fizzBuzz.GetOutput(number);

            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
