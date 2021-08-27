using NUnit.Framework;
using System.Collections.Generic;

namespace TestNinja.Tests.Fundamentals
{
    [TestFixture]
    class MathTests
    {
        private TestNinja.Fundamentals.Math _mathClassObject;

        [SetUp]
        public void SetUp()
        {
            _mathClassObject = new TestNinja.Fundamentals.Math();
        }

        [TearDown]
        public void TearDown()
        {
            _mathClassObject = null;
        }

        [Test]
        public void Add_SumOfTwoNumbers_ReturnAddition()
        {
            //Arrange - Act
            var result = _mathClassObject.Add(1, 2);

            //Assert
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        [TestCase(1,2,2)]
        [TestCase(2,1,2)]
        [TestCase(1,1,1)]
        public void Max_ChooseMaxNumberBetweenTwo_RetunMaxNumber(int a, int b, int expected)
        {
            //Arrange - Act
            var result = _mathClassObject.Max(a, b);

            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetOddNumbers_SelectOddNumbers_ReturnListOfOdd()
        {
            //Arrange - Act
            var result = _mathClassObject.GetOddNumbers(10);

            //Assert
            Assert.That(result, Is.EqualTo(new List<int> {1, 3, 5, 7, 9 }));
        }
    }
}
