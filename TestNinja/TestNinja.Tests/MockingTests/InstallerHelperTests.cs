using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using TestNinja.Mocking;

namespace TestNinja.Tests.MockingTests
{
    [TestFixture]
    class InstallerHelperTests
    {
        //CLASS OBJECT FOR TEST
        private InstallerHelper _installerHelperClass;

        //MOCK OBJECTS
        private Mock<IFileDownloader> _mockFileDownloader; 

        [SetUp]
        public void SetUp()
        {
            _mockFileDownloader = new Mock<IFileDownloader>();
            _installerHelperClass = new InstallerHelper(_mockFileDownloader.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _mockFileDownloader = null;
            _installerHelperClass = null;
        }

        [Test]
        public void DownloadInstaller_CorrectDownload_ReturnTrue()
        {
            //Arrange
            _mockFileDownloader.Setup(mfd => mfd.FileDownload(It.IsAny<string>(), It.IsAny<string>()));

            //Act
            var result = _installerHelperClass.DownloadInstaller("customerName", "installerName");

            //Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void DownloadInstaller_IncorrectDownload_ReturnFalse()
        {
            //Arrange
            _mockFileDownloader.Setup(mfd => mfd.FileDownload(It.IsAny<string>(), It.IsAny<string>())).Throws<WebException>();

            //Act
            var result = _installerHelperClass.DownloadInstaller("customerName", "installerName");

            //Assert
            Assert.That(result, Is.False);
        }
    }
}
