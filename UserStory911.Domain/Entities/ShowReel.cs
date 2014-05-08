using System.Collections.Generic;
using UserStory911.Domain.Enums;

namespace UserStory911.Domain.Entities
{
    /// <summary>
    /// Show Reel entity.
    /// </summary>
    public class ShowReel
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the definition.
        /// </summary>
        /// <value>
        /// The definition.
        /// </value>
        public VideoDefinition Definition { get; set; }

        /// <summary>
        /// Gets or sets the standard.
        /// </summary>
        /// <value>
        /// The standard.
        /// </value>
        public VideoStandard Standard { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }
    }
}