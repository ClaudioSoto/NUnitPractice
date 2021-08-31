using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Mocking;

namespace TestNinja.Tests.Mocking
{
    [TestFixture]
    class VideoServiceTests
    {
        private VideoService _videoServiceClassObject;
        private Mock<IVideoFileReader> _videoFileReader;
        private Mock<IVideoRepository> _videoRepository;

        [SetUp]
        public void SetUp()
        {
            _videoServiceClassObject = new VideoService();
            _videoFileReader = new Mock<IVideoFileReader>();
            _videoRepository = new Mock<IVideoRepository>();
        }

        [TearDown]
        public void TearDown()
        {
            _videoServiceClassObject = null;
            _videoFileReader = null;
            _videoRepository = null;
        }

        [Test]
        public void ReadVideoTitle_FileIsNull_ReturnError()
        {
            //Arrange
            _videoFileReader.Setup(mvs => mvs.readFile("video.txt")).Returns("");

            //Act
            var result = _videoServiceClassObject.ReadVideoTitle(_videoFileReader.Object);

            //Assert
            Assert.That(result, Does.StartWith("Error"));
        }

        [Test]
        public void ReadVideoTitle_FileIsNotNull_ReturnError()
        {
            //Arrange
            _videoFileReader.Setup(mvs => mvs.readFile("video.txt")).Returns(" ");

            //Act
            var result = _videoServiceClassObject.ReadVideoTitle(_videoFileReader.Object);

            //Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_EmptyVideoList_ReturnEmptyString()
        {
            //Arrange
            _videoRepository.Setup(mvr => mvr.getVideos()).Returns(new List<Video>());

            //Act
            var result =_videoServiceClassObject.GetUnprocessedVideosAsCsv(_videoRepository.Object);

            //Assert
            Assert.That(result, Is.EqualTo(""));

        }

        [Test]
        public void GetUnprocessedVideosAsCsv_NotEmptyVideoList_ReturnString()
        {
            //Arrange
            _videoRepository.Setup(mvr => mvr.getVideos()).Returns(new List<Video>() { 
                
                new Video(){Id = 1},
                new Video(){Id = 2},
                new Video(){Id = 3}
            
            });

            //Act
            var result = _videoServiceClassObject.GetUnprocessedVideosAsCsv(_videoRepository.Object);

            //Assert
            Assert.That(result, Is.EqualTo("1,2,3"));

        }
    }
}
