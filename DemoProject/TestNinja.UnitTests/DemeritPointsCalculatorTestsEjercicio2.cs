using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class DemeritPointsCalculatorTestsEjercicio2
    {
        DemeritPointsCalculator _demeritObj;

        [SetUp]
        public void SetUp()
        {
            _demeritObj = new DemeritPointsCalculator();
        }

        [Test]
        [TestCase(-1)]
        [TestCase(301)]
        public void CalculateDemeritPoints_SpeedOutOfRange_ReturnOutRange(int speed)
        {
            Assert.That(() => _demeritObj.CalculateDemeritPoints(speed), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        [TestCase(0,0)]
        [TestCase(64,0)]
        [TestCase(65,0)]
        [TestCase(70, 1)]
        [TestCase(75, 2)]
        public void CalculateDemeritPoints_WhenCallled_ReturnDemeritPoints(int speed, int res)
        {
            var result = _demeritObj.CalculateDemeritPoints(speed);
            Assert.That(result, Is.EqualTo(res));

        }

    

    }
}
