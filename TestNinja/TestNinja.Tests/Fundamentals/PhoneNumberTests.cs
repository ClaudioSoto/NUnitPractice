using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Fundamentals;

namespace TestNinja.Tests.Fundamentals
{
    [TestFixture]
    class PhoneNumberTests
    {
        private PhoneNumber _phoneNumberClassObject;

        [SetUp]
        public void SetUp()
        {
            _phoneNumberClassObject = new PhoneNumber("", "", "");
        }

        [TearDown]
        public void TearDown()
        {
            _phoneNumberClassObject = null;
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void PhoneNumber_NullOrWhiteSpace_ThrowArgumentException(string number)
        {
            //Arrange - Act - Assert
            Assert.That(() => _phoneNumberClassObject.Parse(number), Throws.ArgumentException);
        }

        [Test]
        [TestCase("4")]
        [TestCase("442542614")]
        [TestCase("44254261412")]
        public void PhoneNumber_NumberLengthDifferentFromTen_ThrowArgumentException(string number)
        {
            //Act - Assert
            Assert.That(() => _phoneNumberClassObject.Parse(number), Throws.ArgumentException);
        }

        [Test]
        public void PhoneNumber_CorrectPhoneNumber_ThrowArgumentException()
        {
            //Arrange - Act
            var result = _phoneNumberClassObject.Parse("4425426141");

            //Act - Assert
            
            Assert.That(result.Area, Is.EqualTo("442"));
            Assert.That(result.Major, Is.EqualTo("542"));
            Assert.That(result.Minor, Is.EqualTo("6141"));
        }

        [Test]
        public void ToString_FormatPhoneNumber_ReturnFormattedPhoneNumber()
        {
            //Arrange
            _phoneNumberClassObject = new PhoneNumber("442", "542", "6141");

            //Act
            var result = _phoneNumberClassObject.ToString();

            //Assert
            Assert.That(result, Does.StartWith("(442)"));
            Assert.That(result, Does.Contain("542-"));
            Assert.That(result, Does.EndWith("6141"));
        }
    }
}
