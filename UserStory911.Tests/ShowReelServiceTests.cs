using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UserStory911.Domain.Entities;
using UserStory911.Domain.Enums;
using UserStory911.Domain.Services;

namespace UserStory911.Tests
{
    [TestClass]
    public class ShowReelServiceTests
    {
        private ShowReel showReel;

        private ShowReelService showReelService;

        private Mock<IShowReelService> showReelServiceMock;

        private Mock<IRepository<ShowReel>> showReelRepositoryMock;

        [TestInitialize]
        public void Init()
        {
            this.showReel = new ShowReel();

            // Mocks
            this.showReelRepositoryMock = new Mock<IRepository<ShowReel>>(MockBehavior.Strict);
            this.showReelServiceMock = new Mock<IShowReelService>(MockBehavior.Strict);

            this.showReelServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(this.showReel);
            this.showReelRepositoryMock
                .Setup(x => x.Find(It.IsAny<Expression<Func<ShowReel, bool>>>())).Returns(new[] { this.showReel });


            // Concrete
            this.showReelService = new ShowReelService(this.showReelRepositoryMock.Object);

        }

        [TestMethod]
        public void Should_get_show_reel_by_id()
        {
            // Arrange

            // Act
            var result = this.showReelService.Get(this.showReel.Id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreSame(this.showReel, result);
        }

        [TestMethod]
        public void User_should_be_able_to_create_a_reel_with_a_name()
        {
            // Arrange
            this.showReelRepositoryMock.Setup(x => x.Create()).Returns(this.showReel);
            this.showReelRepositoryMock.Setup(x => x.Add(It.IsAny<ShowReel>()));

            // Act
            var result = this.showReelService.Create(this.showReel);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ShowReel));
            this.showReelRepositoryMock.Verify(x => x.Create(), Times.Once);
            this.showReelRepositoryMock.Verify(x => x.Add(It.IsAny<ShowReel>()), Times.Once);
        }
    }
}
