using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestNinja.Tests
{
    [TestFixture]
    class MathTests
    {
        private Fundamentals.Math _math;

        [SetUp]
        public void SetUp()
        {
            _math = new Fundamentals.Math();
        }

        [TearDown]
        public void TearDown()
        {
            _math = null;
        }

        [Test]
        [TestCase(1,2,3)]
        [TestCase(1,-2,-1)]
        [TestCase(-1,2,1)]
        public void Add_WhenCalled_ReturnSumOfNumbers(int a, int b, int expected)
        {
            //Arrange - Act
            var result = _math.Add(a, b);

            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Max_FirstNumberIsTheMaxOne_ReturnFirstNumber()
        {
            //Arrange - Act
            var result = _math.Max(2, 1);

            //Assert
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void Max_SecondNumberIsTheMaxOne_ReturnSecondNumber()
        {
            //Arrange - Act
            var result = _math.Max(2, 3);

            //Assert
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void Max_SameNumberIsTheMaxOne_ReturnFirstNumber()
        {
            //Arrange - Act
            var result = _math.Max(1, 1);

            //Assert
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void GetOddNumbers_GreaterThanZero_ReturnOddNumbersUpToLimit()
        {
            //Arrange - Act
            var result = _math.GetOddNumbers(5);

            //Assert
            Assert.That(result, Is.Not.Empty);
            Assert.That(result, Is.EquivalentTo(new[] { 1, 3, 5 }));
            Assert.That(result, Is.Ordered);
            Assert.That(result, Is.Unique);
        }

    }
}
