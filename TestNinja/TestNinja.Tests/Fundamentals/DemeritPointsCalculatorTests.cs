using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Fundamentals;

namespace TestNinja.Tests.Fundamentals
{
    [TestFixture]
    class DemeritPointsCalculatorTests
    {
        private DemeritPointsCalculator _demeritPointsClassObject;

        [SetUp]
        public void SetUp()
        {
            _demeritPointsClassObject = new DemeritPointsCalculator();
        }

        [Test]
        [TestCase(-1)]
        [TestCase(301)]
        public void CalculateDemeritPoints_NegativeOrOverMaxSpeed_ReturnArgumentOutOfRangeException(int speed)
        {
            //Arrange - Act - Assert
            Assert.That(() => _demeritPointsClassObject.CalculateDemeritPoints(speed), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        [TestCase(64, 0)]
        [TestCase(65, 0)]
        [TestCase(70,1)]
        [TestCase(75, 2)]
        public void CalculateDemeritPoints_WhenCalled_ReturnDemeritPoints(int speed, int expected)
        {
            //Arrange - Act - Assert
            Assert.That(() => _demeritPointsClassObject.CalculateDemeritPoints(speed), Is.EqualTo(expected));
        }
    }
}
