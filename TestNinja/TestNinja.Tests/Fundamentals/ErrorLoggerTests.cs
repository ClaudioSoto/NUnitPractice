using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Fundamentals;

namespace TestNinja.Tests.Fundamentals
{
    [TestFixture]
    class ErrorLoggerTests
    {
        private ErrorLogger _errorLoggerClassObject;

        [SetUp]
        public void SetUp()
        {
            _errorLoggerClassObject = new ErrorLogger();
        }

        [TearDown]
        public void TearDown()
        {
            _errorLoggerClassObject = null;
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Log_NullOrWhiteSpaceError_ThrowArgumentNullException(string error)
        {
            //Arrange - Act - Assert
            Assert.That(() => _errorLoggerClassObject.Log(error), Throws.ArgumentNullException);
        }

        [Test]
        public void Log_ErrorIsNotNullOrEmpty_ErrorLogged()
        {
            //Arrange - Act
            _errorLoggerClassObject.Log("a");
            
            //Assert
            Assert.That(_errorLoggerClassObject.LastError, Is.EqualTo("a"));
        }

        [Test]
        public void Log_ValidError_RaiseErrorLoggedEvent()
        {
            //Arrange
            var id = Guid.Empty;
            _errorLoggerClassObject.ErrorLogged += (sender, args) => { id = args; };

            //Act
            _errorLoggerClassObject.Log("a");

            //Assert
            Assert.That(id, Is.Not.EqualTo(Guid.Empty));
        }
    }
}
