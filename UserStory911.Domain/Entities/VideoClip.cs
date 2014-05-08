using System;
using UserStory911.Domain.Enums;

namespace UserStory911.Domain.Entities
{
    /// <summary>
    /// The video clip.
    /// </summary>
    public class VideoClip
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the video standard.
        /// </summary>
        /// <value>
        /// The video standard.
        /// </value>
        public VideoStandard VideoStandard { get; set; }

        /// <summary>
        /// Gets or sets the video definition.
        /// </summary>
        /// <value>
        /// The video definition.
        /// </value>
        public VideoDefinition VideoDefinition { get; set; }

        /// <summary>
        /// Gets or sets the start time code.
        /// </summary>
        /// <value>
        /// The start time code.
        /// </value>
        public TimeSpan StartTimeCode { get; set; }

        /// <summary>
        /// Gets or sets the end time code.
        /// </summary>
        /// <value>
        /// The end time code.
        /// </value>
        public TimeSpan EndTimeCode { get; set; }

        /// <summary>
        /// Gets or sets the show reel identifier.
        /// </summary>
        /// <value>
        /// The show reel identifier.
        /// </value>
        public int ShowReelId { get; set; }
    }
}