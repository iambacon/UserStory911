using System.Web.Http;
using UserStory911.Domain.Entities;
using UserStory911.Domain.Services;

namespace UserStory911.Controllers.api
{
    /// <summary>
    /// The show reel api controller.
    /// </summary>
    [RoutePrefix("api/showreel")]
    public class ShowReelController : ApiController
    {
        /// <summary>
        /// The show reel service.
        /// </summary>
        private readonly IShowReelService showReelService;

        /// <summary>
        /// The video clip service.
        /// </summary>
        private readonly IVideoClipService videoClipService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShowReelController"/> class.
        /// </summary>
        /// <param name="videoClipService">The video clip service.</param>
        /// <param name="showReelService">The show reel service.</param>
        public ShowReelController(IVideoClipService videoClipService, IShowReelService showReelService)
        {
            this.showReelService = showReelService;
            this.videoClipService = videoClipService;
        }

        // POST api/<controller>
        [Route("")]
        [HttpPost]
        public int Post([FromBody]ShowReel showReel)
        {
            var entity = this.showReelService.Create(showReel);

            return entity.Id;
        }

        // POST api/<controller>/clip/{clip}
        [Route("clip")]
        [HttpPost]
        public int PostClip([FromBody] VideoClip clip)
        {
            var entity = this.videoClipService.Create(clip);

            return entity.Id;
        }

        // DELETE api/<controller>/clip/5
        [Route("clip")]
        [HttpDelete]
        public void DeleteClip([FromBody]int id)
        {
            this.videoClipService.Delete(id);
        }
    }
}