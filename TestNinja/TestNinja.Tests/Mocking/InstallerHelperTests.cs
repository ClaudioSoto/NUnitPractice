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
        private Mock<IInstallerHelperTests> _mockInstallerHelper;
        
        [SetUp]
        public void SetUp()
        {
            _mockInstallerHelper = new Mock<IInstallerHelperTests>();
            _installerHelper = new InstallerHelper(_mockInstallerHelper.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _mockInstallerHelper = null;
            _installerHelper = null;
        }

        [Test]
        public void DownloadInstaller_FailToDownloadFile_ReturnWebException()
        {
            //Arrange
            _mockInstallerHelper.Setup(mih => mih.downloadFile("a", "b")).Throws<WebException>();

            //Act
            var result = _installerHelper.DownloadInstaller("a","b");

            //Assert
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void DownloadInstaller_SuccessToDownloadFile_ReturnTrue()
        {
            //Arrange
            _mockInstallerHelper.Setup(mih => mih.downloadFile("a", "b"));

            //Act
            var result = _installerHelper.DownloadInstaller("a", "b");

            //Assert
            Assert.That(result, Is.EqualTo(true));
        }

    }
}
