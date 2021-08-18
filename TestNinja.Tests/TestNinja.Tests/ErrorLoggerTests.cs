using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Fundamentals;

namespace TestNinja.Tests
{
    [TestFixture]
    class ErrorLoggerTests
    {
        private ErrorLogger _errorLogger;

        [SetUp]
        public void SetUp()
        {
            _errorLogger = new ErrorLogger();
        }

        [TearDown]
        public void TearDown()
        {
            _errorLogger = null;
        }

        [Test]
        public void Log_NotEmpetyOrSpaceError_SameError()
        {
            //Arrange - Act
            var logger = _errorLogger;
            logger.Log("claudio");

            //Assert
            Assert.That(logger.LastError, Is.EqualTo("claudio"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Log_EmptyAndWhiteSpaceError_ThrowArgumentNullException(string error)
        {
            //Arrange
            var logger = _errorLogger;
 
            //Act - Assert
            Assert.That(()=> logger.Log(error), Throws.ArgumentNullException);
        }

        //This test is when an event is raised up
        [Test]
        public void Log_ValidError_RaiseErrorLoggedEvent()
        {
            //Arrange
            var logger = _errorLogger;

            //Create annonymous function to validate if the error was correctly logged,
            //then we have to store the od using the args when function is executed
            var id = Guid.Empty;
            logger.ErrorLogged += (sender, args) => { id = args; };

            //Act
            //if I dont act, the id will remain empty since the event will be not triggered
            //meaning that there is not error logged to the moment
            logger.Log("claudio");

            //Assert
            //Here we check if the arg GUID stored in id is not empty,
            //If not empty that means the error was stored correctly
            Assert.That(id, Is.Not.EqualTo(Guid.Empty));
        }
    }
}
