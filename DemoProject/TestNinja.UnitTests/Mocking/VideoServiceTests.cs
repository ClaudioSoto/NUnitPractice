using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{

    [TestFixture]
    class VideoServiceTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        /* INJECTION DEPENDENCY METHOD*/
        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnErrorMessage()
        {
            //Arrange
            //create a mock object to simulate FakeFileReader
            var mockFileReader = new Mock<IFileReader>();
            var service = new VideoService(mockFileReader.Object);

            //Act - le pasamos el objeto falso que regresa un string vacio
            mockFileReader.Setup(mfr => mfr.Read("video.txt")).Returns("");
            var result = service.ReadVideoTitle();

            //Assert
            Assert.That(result, Is.EqualTo("Error parsing the video."));
        }


        /* INJECTION DEPENDENCY PROPERTIES*/
        /*
        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnErrorMessage()
        {
            //Arrange
            VideoService service = new VideoService();
            service.fileReader = new FakeFileReader();

            //Act - le pasamos el objeto falso que regresa un string vacio
            var result = service.ReadVideoTitle();

            //Assert
            Assert.That(result, Is.EqualTo("Error parsing the video."));
        }
        */
    }

}
