namespace DEV_4
{
    /// <summary>
    /// Struct for presentation for lectures
    /// </summary>
    struct Presentation
    {
        public string Uri { get; set; }
        public PresentationAllTypes Type;

        public Presentation(string uri, PresentationAllTypes type = PresentationAllTypes.Unknown)
        {
            this.Uri = uri;
            this.Type = type;
        }
    }
}