using System.CodeDom;
using System.Collections.Generic;
using System.Net.Mime;

namespace DEV_4
{
    struct Presentation
    {
        public string Text { get; set; }
        private const int TextMaxLength = 100000;
        public string Uri { get; set; }
        public PresentationAllTypes Type;

        public enum PresentationAllTypes
        {
            Unknown,
            PPT,
            PDF
        }

        public Presentation(string text, string uri, PresentationAllTypes type = PresentationAllTypes.Unknown)
        {
            Text = text.WithMaxLength(TextMaxLength);
            Uri = uri;
            Type = type;
        }
    }
}
