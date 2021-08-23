using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Mocking;

namespace TestNinja.Tests.MockingTests
{
    [TestFixture]
    class VideoServiceTests
    {
        //CLASS OBJECT FOR TEST
        private VideoService _videoServiceClass;

        //MOCK OBJECTS
        private Mock<IVideoFileReader> _mockVideoFileReader;
        private Mock<IVideoRepository> _mockVideoRepository;

        [SetUp]
        public void SetUp()
        {
            _mockVideoFileReader = new Mock<IVideoFileReader>();
            _mockVideoRepository = new Mock<IVideoRepository>();

            _videoServiceClass = new VideoService(_mockVideoFileReader.Object, _mockVideoRepository.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _mockVideoFileReader = null;
            _mockVideoRepository = null;
        }

        [Test]
        public void ReadVideoTitle_WhenVideoFileIsNull_ReturnError()
        {
            //Arrange
            _mockVideoFileReader.Setup(mvfr => mvfr.ReadAllText("video.txt")).Returns("");

            //Act
            var result = _videoServiceClass.ReadVideoTitle();

            //Assert
            Assert.That(result, Does.Contain("Error"));
        }

        [Test]
        public void ReadVideoTitle_WhenPassAValidVideoFile_ReturnVideoTitle()
        {
            //Arrange
            _mockVideoFileReader.Setup(mvfr => mvfr.ReadAllText("video.txt")).Returns(" ");

            //Act
            var result = _videoServiceClass.ReadVideoTitle();

            //Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_EmptyListFileVideos_ReturnEmpty()
        {
            //Arrange
            _mockVideoRepository.Setup(mvr => mvr.ListOfVideos()).Returns(new List<Video>());

            //Act
            var result = _videoServiceClass.GetUnprocessedVideosAsCsv();

            //Assert
            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_ValidListFileVideos_ReturnString()
        {
            //Arrange
            _mockVideoRepository.Setup(mvr => mvr.ListOfVideos()).Returns(new List<Video>()
            {
                new Video() {Id = 1},
                new Video() {Id = 2},
                new Video() {Id = 3}

            });

            //Act
            var result = _videoServiceClass.GetUnprocessedVideosAsCsv();

            //Assert
            Assert.That(result, Is.EqualTo("1,2,3"));
        }
    }
}
