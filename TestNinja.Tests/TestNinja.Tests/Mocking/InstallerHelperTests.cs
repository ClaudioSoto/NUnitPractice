using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using TestNinja.Mocking;

namespace TestNinja.Tests.Mocking
{
    [TestFixture]
    class InstallerHelperTests
    {
        private InstallerHelper _installerHelper;

        [SetUp]
        public void SetUp()
        {
            _installerHelper = new InstallerHelper();
        }

        [TearDown]
        public void TearDown()
        {
            _installerHelper = null;
        }

        [Test]
        public void DownloadInstaller_DownloadFails_ReturnFalse()
        {
            //Arrange
            var installerHelper = _installerHelper;
            var mockFileDownloader = new Mock<IFileDownloader>();

            //Act
            //THIS IS TO MUCH SPECIFIC
            //mockFileDownloader.Setup(mfd => mfd.DownloadFile("http://example.com/customer/installer", null)).Throws<WebException>();
            
            //THEN WE USE THE FRAMEWORK
            mockFileDownloader.Setup(mfd => mfd.DownloadFile(It.IsAny<string>(), It.IsAny<string>())).Throws<WebException>();
            var result = installerHelper.DownloadInstaller("customer", "installer", mockFileDownloader.Object);

            //Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void DownloadInstaller_DownloadSuccess_ReturnTrue()
        {
            //Arrange
            var installerHelper = _installerHelper;
            var mockFileDownloader = new Mock<IFileDownloader>();

            //Act
            mockFileDownloader.Setup(mfd => mfd.DownloadFile(It.IsAny<string>(), It.IsAny<string>()));
            var result = installerHelper.DownloadInstaller("customer", "installer", mockFileDownloader.Object);

            //Assert
            Assert.That(result, Is.True);
        }
    }
}
