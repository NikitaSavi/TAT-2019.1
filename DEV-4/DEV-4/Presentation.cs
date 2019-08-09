namespace DEV_4
{
    /// <summary>
    /// Struct for presentation for lectures
    /// </summary>
    public struct Presentation
    {
        /// <summary>
        /// Gets or sets the uri.
        /// </summary>
        public string Uri { get; set; }

        /// <summary>
        /// The type.
        /// </summary>
        public PresentationAllTypes Type;

        /// <summary>
        /// Initializes a new instance of the <see cref="Presentation"/> struct.
        /// </summary>
        /// <param name="uri">
        /// The uri.
        /// </param>
        /// <param name="type">
        /// The type.
        /// </param>
        public Presentation(string uri, PresentationAllTypes type = PresentationAllTypes.Unknown)
        {
            this.Uri = uri;
            this.Type = type;
        }
    }
}