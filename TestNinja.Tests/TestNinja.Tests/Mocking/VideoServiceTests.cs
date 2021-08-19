using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using TestNinja.Mocking;

namespace TestNinja.Tests.Mocking
{
    [TestFixture]
    class VideoServiceTests
    {
        private VideoService _videoService;

        [SetUp]
        public void SetUp()
        {
            _videoService = new VideoService();
            
        }

        [TearDown]
        public void TearDown()
        {
            _videoService = null;
        }

        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            //Arrange
            var service = _videoService;
            var mockFileReader = new Mock<IFileReader>();

            //Act
            mockFileReader.Setup(mfr => mfr.Read("video.txt")).Returns("");
            var result = service.ReadVideoTitle(mockFileReader.Object);

            //Assert
            Assert.That(result, Is.EqualTo("Error parsing the video."));
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_NoVideosInTheRepository_ReturnEmptyString()
        {

            //Arrange 
            var service = _videoService;
            var mockVideoRepository = new Mock<IVideoRepository>();

            //Act
            mockVideoRepository.Setup(mvr => mvr.GetUnprocessedVideos()).Returns(new List<Video>());
            var result = service.GetUnprocessedVideosAsCsv(mockVideoRepository.Object);

            //Assert
            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_ExistingVideosInTheRepository_ReturnStringWithIdsVideos()
        {
            //Arrange
            var service = _videoService;
            var mockVideoRepository = new Mock<IVideoRepository>();

            //Act
            mockVideoRepository.Setup(mvr => mvr.GetUnprocessedVideos()).Returns(new List<Video>
            {
                new Video() {Id = 1},
                new Video() {Id = 2},
                new Video() {Id = 3},
            });
            var result = service.GetUnprocessedVideosAsCsv(mockVideoRepository.Object);

            //Assert
            Assert.That(result, Is.EqualTo("1,2,3"));
        }
    }
}
