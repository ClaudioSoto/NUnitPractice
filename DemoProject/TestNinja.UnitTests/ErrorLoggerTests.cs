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

        //ejermplo para cuando se realizan excepciones
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
