namespace DEV_4
{
    /// <summary>
    /// Class for containing general information of entities (GUID and Description)
    /// </summary>
    public class EntityData
    {
        /// <summary>
        /// Gets or sets the entity guid.
        /// </summary>
        public string EntityGuid { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The description max length.
        /// </summary>
        private const int DescriptionMaxLength = 256;

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityData"/> class.
        /// </summary>
        /// <param name="description">
        /// The description.
        /// </param>
        public EntityData(string description = null)
        {
            this.Description = description.WithMaxLength(DescriptionMaxLength);
            this.EntityGuid = this.EntityGuid.GenerateGuid();
        }
    }
}
