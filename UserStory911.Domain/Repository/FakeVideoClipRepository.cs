using UserStory911.Domain.Entities;

namespace UserStory911.Domain.Repository
{
    /// <summary>
    /// The fake video clip repository.
    /// </summary>
    public class FakeVideoClipRepository : FakeRepositoryBase<VideoClip>
    {
        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public override void Add(VideoClip entity)
        {
            entity.Id = this.data.Count;

            this.data.Add(entity);
        }
    }
}
