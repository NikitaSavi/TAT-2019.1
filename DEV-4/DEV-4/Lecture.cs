using System.Collections.Generic;
using System.Linq;

namespace DEV_4
{
    class Lecture : Material
    {
        public string Text { get; set; }
        private const int TextMaxLength = 100000;

        public string Uri { get; set; }
        public string PresentationType { get; set; }

        public List<Seminar> ListOfSeminarsToThisLecture = new List<Seminar>();
        public List<Labwork> ListOfLabworksToThisLecture = new List<Labwork>();
        private static readonly string[] PresentationsAllTypes = {"PPT", "PDF"};

        public Lecture(string text, string uri, string presentationType = "Unknown",
            string description = null) : base(description)
        {
            Text = text.WithMaxLength(TextMaxLength);
            Uri = uri;
            if (PresentationsAllTypes.Contains(presentationType))
            {
                PresentationType = presentationType;
            }
        }
    }
}