namespace DEV_4
{
    struct Presentation
    {
        public string Uri { get; set; }
        public PresentationAllTypes Type;

        public enum PresentationAllTypes
        {
            Unknown,
            PPT,
            PDF
        }

        public Presentation(string uri, PresentationAllTypes type = PresentationAllTypes.Unknown)
        {
            Uri = uri;
            Type = type;
        }
    }
}
