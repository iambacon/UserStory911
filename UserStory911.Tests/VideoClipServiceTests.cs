using System;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UserStory911.Domain.Entities;
using UserStory911.Domain.Enums;
using UserStory911.Domain.Services;

namespace UserStory911.Tests
{
    [TestClass]
    public class VideoClipServiceTests
    {
        private VideoClipService videoClipService;

        private Mock<IVideoClipService> videoClipServiceMock;

        private VideoClip clip1;

        private Mock<IRepository<VideoClip>> videoClipRepositoryMock;

        private Mock<IShowReelService> showReelServiceMock;

        [TestInitialize]
        public void Init()
        {
            // Mocks
            this.videoClipRepositoryMock = new Mock<IRepository<VideoClip>>(MockBehavior.Strict);
            this.showReelServiceMock = new Mock<IShowReelService>(MockBehavior.Strict);
            this.videoClipServiceMock = new Mock<IVideoClipService>(MockBehavior.Strict);

            // Concrete
            this.videoClipService = new VideoClipService(this.showReelServiceMock.Object, this.videoClipRepositoryMock.Object);

            this.clip1 = new VideoClip
            {
                VideoDefinition = VideoDefinition.Sd,
                VideoStandard = VideoStandard.Pal,
                EndTimeCode = new TimeSpan(1, 10, 3, 40),
                Id = 5,
                ShowReelId = 2
            };
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void User_should_not_be_able_to_add_both_NTSC_and_PAL_clips_to_a_reel()
        {
            // Arrange
            this.showReelServiceMock.Setup(x => x.Get(It.IsAny<int>()))
                .Returns(new ShowReel { Standard = VideoStandard.Ntsc });

            // Act
            this.videoClipService.Create(this.clip1);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void User_should_not_be_able_to_add_both_HD_and_SD_clips_to_a_reel()
        {
            // Arrange
            this.showReelServiceMock.Setup(x => x.Get(It.IsAny<int>()))
                .Returns(new ShowReel { Definition = VideoDefinition.Hd });

            // Act
            this.videoClipService.Create(this.clip1);

            // Assert
        }

        [TestMethod]
        public void User_should_be_able_to_add_a_clip()
        {
            // Arrange
            this.showReelServiceMock.Setup(x => x.Get(It.IsAny<int>()))
                .Returns(new ShowReel { Id = 2 });

            this.videoClipRepositoryMock.Setup(x => x.Create()).Returns(new VideoClip());
            this.videoClipRepositoryMock.Setup(x => x.Add(It.IsAny<VideoClip>()));

            // Act
            var result = this.videoClipService.Create(this.clip1);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void User_should_be_able_to_remove_a_clip()
        {
            // Arrange
            this.videoClipServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(this.clip1);
            this.videoClipRepositoryMock.Setup(x => x.Remove(It.IsAny<VideoClip>()));
            this.videoClipRepositoryMock
                .Setup(x => x.Find(It.IsAny<Expression<Func<VideoClip, bool>>>())).Returns(new[] { this.clip1 });

            // Act
            this.videoClipService.Delete(this.clip1.Id);

            // Assert
            this.videoClipRepositoryMock.Verify(x => x.Remove(It.IsAny<VideoClip>()), Times.Once);
        }

        [TestMethod]
        public void Should_be_able_to_get_a_clip()
        {
            // Arrange
            this.videoClipRepositoryMock
                .Setup(x => x.Find(It.IsAny<Expression<Func<VideoClip, bool>>>())).Returns(new[] { this.clip1 });

            // Act
            this.videoClipService.Get(this.clip1.Id);

            // Assert
            this.videoClipRepositoryMock
                .Verify(x => x.Find(It.IsAny<Expression<Func<VideoClip, bool>>>()), Times.Once);
        }
    }
}
