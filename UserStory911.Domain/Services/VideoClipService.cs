using System;
using System.Linq;
using UserStory911.Domain.Entities;

namespace UserStory911.Domain.Services
{
    /// <summary>
    /// The video clip service.
    /// </summary>
    public class VideoClipService : IVideoClipService
    {
        /// <summary>
        /// The video clip repository.
        /// </summary>
        private readonly IRepository<VideoClip> videoClipRepository;

        /// <summary>
        /// The show reel service.
        /// </summary>
        private readonly IShowReelService showReelService;

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoClipService"/> class.
        /// </summary>
        public VideoClipService(IShowReelService showReelService, IRepository<VideoClip> videoClipRepository)
        {
            this.videoClipRepository = videoClipRepository;
            this.showReelService = showReelService;
        }

        /// <summary>
        /// Deletes the clip by the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(int id)
        {
            // In the real world this would perform a db operation.
            var entity = this.videoClipRepository.Find(x => x.Id == id).FirstOrDefault();
            this.videoClipRepository.Remove(entity);
        }

        /// <summary>
        /// Creates the specified clip.
        /// </summary>
        /// <param name="clip">The clip.</param>
        /// <returns></returns>
        public VideoClip Create(VideoClip clip)
        {
            var showReel = this.showReelService.Get(clip.ShowReelId);

            if (clip.VideoDefinition != showReel.Definition)
            {
                throw new Exception(
                    string.Format("Only {0} definition clips can be added to this reel", showReel.Definition));
            }

            if (clip.VideoStandard != showReel.Standard)
            {
                throw new Exception(
                    string.Format("Only {0} standard clips can be added to this reel", showReel.Standard));
            }

            // In the real world this would perform a db operation.
            var entity = this.videoClipRepository.Create();

            entity.ShowReelId = clip.ShowReelId;
            entity.Name = clip.Name;
            entity.Description = clip.Description;
            entity.EndTimeCode = clip.EndTimeCode;
            entity.StartTimeCode = clip.StartTimeCode;
            entity.VideoDefinition = clip.VideoDefinition;
            entity.VideoStandard = clip.VideoStandard;

            this.videoClipRepository.Add(entity);

            return entity;
        }

        /// <summary>
        /// Gets the clip by the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public VideoClip Get(int id)
        {
            var entity = this.videoClipRepository.Find(x => x.Id == id).FirstOrDefault();

            return entity;
        }
    }
}
