using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Math = TestNinja.Fundamentals.Math;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class MathTests
    {
        //Create the object for the target class in order to avoid repeat the code
        private Math _math;

        //We use SetUp tag in order to execute the target method after every test
        [SetUp]
        public void SetUp()
        {
            _math = new Math();
        }

        [Test]
        public void Add_WhenCalled_ReturnTheSumOfArguments()
        {
            //Arrange
            //Math math = new Math();

            //Act
            //We add simple values in order to avoid confusion on especific values
            int result = _math.Add(1, 2);

            //Assert
            Assert.AreEqual(3, result);
        }

        /*
         * When test cases return the same but with different parameters
         * It's necessary to use a generic name in the method when [TestCase()] tag is used
         */
        [Test]
        [TestCase(2,1,2)]
        [TestCase(1, 2, 2)]
        [TestCase(2, 2, 2)]
        public void Max_WhenCalled_ReturnTheGreaterArgument(int a, int b, int expected)
        {
            //Act
            int result = _math.Max(a, b);

            //Assert
            Assert.AreEqual(result, expected);
        }

        //Method to assert arrays and collections
        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersUpToTheLimit()
        {
            //Arrange - Act
            var result = _math.GetOddNumbers(5);

            //Assert
            Assert.That(result, Is.EqualTo(new[] { 1, 3, 5 }));
        }
    }
}
