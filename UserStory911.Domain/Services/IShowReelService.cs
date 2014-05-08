using UserStory911.Domain.Entities;

namespace UserStory911.Domain.Services
{
    /// <summary>
    /// The show reel service interface.
    /// </summary>
    public interface IShowReelService
    {
        /// <summary>
        /// Creates the show reel.
        /// </summary>
        /// <param name="reel">The reel.</param>
        /// <returns></returns>
        ShowReel Create(ShowReel reel);

        /// <summary>
        /// Gets the show reel by the specified id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        ShowReel Get(int id);
    }
}
