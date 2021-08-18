using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Fundamentals;

namespace TestNinja.Tests
{
    [TestFixture]
    class DemeritPointsCalculatorTests
    {
        private DemeritPointsCalculator _demeritPointsCalculator;

        [SetUp]
        public void SetUp()
        {
            _demeritPointsCalculator = new DemeritPointsCalculator();
        }

        [TearDown]
        public void TearDown()
        {
            _demeritPointsCalculator = null;
        }

        [Test]
        [TestCase(-1)]
        [TestCase(301)]
        public void CalculateDemeritPoints_SpeedIsLessThanZeroOrGreaterThanMaxSpeed_ThrowArgumentOutOfRangeException(int speed)
        {
            //Arrange
            var demerit = _demeritPointsCalculator;

            //Act - Assert
            Assert.That(() => demerit.CalculateDemeritPoints(speed), Throws.InstanceOf<ArgumentOutOfRangeException>());

        }

        [Test]
        [TestCase(64)]
        [TestCase(65)]
        public void CalculateDemeritPoints_SpeedIsLessOrEqualToSpeedLimit_ReturnZero(int speed)
        {
            //Arrange - Act
            var result = _demeritPointsCalculator.CalculateDemeritPoints(speed);

            //Assert
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        [TestCase(70,1)]
        [TestCase(75,2)]
        public void CalculateDemeritPoints_SpeedIsGreaterThanSpeedLimitAndLessThanMaxSpeed_ReturnDemeritPoints(int speed, int expected)
        {
            //Arrange - Act
            var result = _demeritPointsCalculator.CalculateDemeritPoints(speed);

            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
