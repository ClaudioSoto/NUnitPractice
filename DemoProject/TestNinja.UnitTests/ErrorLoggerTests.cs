using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class ErrorLoggerTests
    {
        [Test]
        public void Log_WhenCalled_SetTheLastErrorLog()
        {
            //Arrange
            ErrorLogger errorObj = new ErrorLogger();

            //Act
            errorObj.Log("a");

            //Assert
            Assert.That(errorObj.LastError, Is.EqualTo("a"));
        }

        //When exeption is used you have to declare an annonymous function and use the Throws object to compare
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Log_InvalidError_ReturnArgumentNullException(string error)
        {
            //Arrange
            ErrorLogger errorObj = new ErrorLogger();

            //Act -Assert
            Assert.That(() => errorObj.Log(error), Throws.ArgumentNullException);
        }


    }
}
