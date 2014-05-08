using System;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UserStory911.Domain.Entities;
using UserStory911.Domain.Enums;
using UserStory911.Domain.Repository;
using UserStory911.Domain.Services;

namespace UserStory911.Tests
{
    [TestClass]
    public class Requirements
    {
        private IShowReelService showReelService;

        private IVideoClipService videoClipService;

        private Mock<IShowReelService> showReelServiceMock;

        private Mock<IRepository<ShowReel>> showReelRepositoryMock;

        private Mock<IRepository<VideoClip>> videoClipRepositoryMock;

        private FakeShowReelRepository showReelRepository;

        private VideoClip clip1;

        private VideoClip clip2;

        private ShowReel showReel;

        [TestInitialize]
        public void Init()
        {
            this.showReelRepository = new FakeShowReelRepository();
            this.showReelService = new ShowReelService(this.showReelRepository);

            this.showReelServiceMock = new Mock<IShowReelService>(MockBehavior.Strict);
            this.videoClipRepositoryMock = new Mock<IRepository<VideoClip>>(MockBehavior.Strict);
            this.showReelRepositoryMock = new Mock<IRepository<ShowReel>>();
            this.showReelRepository = new FakeShowReelRepository();

            this.showReelServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(new ShowReel());

            this.clip1 = new VideoClip
            {
                VideoDefinition = VideoDefinition.Sd,
                VideoStandard = VideoStandard.Pal,
                EndTimeCode = new TimeSpan(1, 10, 3, 40),
                Id = 5,
                ShowReelId = 2
            };
            this.clip2 = new VideoClip
            {
                VideoDefinition = VideoDefinition.Hd,
                VideoStandard = VideoStandard.Ntsc,
                Id = 6,
                ShowReelId = 1
            };
            this.showReel = new ShowReel { Id = 2 };

            this.videoClipService = new VideoClipService(this.showReelServiceMock.Object, new FakeRepositoryBase<VideoClip>());
        }

        

        
    }
}