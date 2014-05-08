using System.Linq;
using UserStory911.Domain.Entities;
using UserStory911.Domain.Repository;

namespace UserStory911.Domain.Services
{
    /// <summary>
    /// The show reel service.
    /// </summary>
    public class ShowReelService : IShowReelService
    {
        /// <summary>
        /// The show reel repository.
        /// </summary>
        private readonly IRepository<ShowReel> showReelRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShowReelService"/> class.
        /// </summary>
        public ShowReelService(IRepository<ShowReel> showReelRepository)
        {
            this.showReelRepository = showReelRepository;
        }

        /// <summary>
        /// Creates the show reel.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public ShowReel Create(ShowReel reel)
        {
            // In the real world this would perform a db operation.
            var entity = this.showReelRepository.Create();
            entity.Name = reel.Name;
            entity.Standard = reel.Standard;
            entity.Definition = reel.Definition;

            this.showReelRepository.Add(entity);

            return entity;
        }

        /// <summary>
        /// Gets the show reel by the specified id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ShowReel Get(int id)
        {
            // In the real world this would perform a db operation.
            var entity = this.showReelRepository.Find(x => x.Id == id).FirstOrDefault();
            return entity;
        }
    }
}
