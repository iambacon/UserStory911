using UserStory911.Domain.Entities;

namespace UserStory911.Domain.Services
{
    /// <summary>
    /// The video clip service interface.
    /// </summary>
    public interface IVideoClipService
    {
        /// <summary>
        /// Deletes the clip by the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void Delete(int id);

        /// <summary>
        /// Creates the specified clip.
        /// </summary>
        /// <param name="clip">The clip.</param>
        /// <returns></returns>
        VideoClip Create(VideoClip clip);

        /// <summary>
        /// Gets the clip by the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        VideoClip Get(int id);
    }
}
