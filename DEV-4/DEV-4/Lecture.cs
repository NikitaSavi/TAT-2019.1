using System.Collections.Generic;
using System.Linq;

namespace DEV_4
{
    /// <summary>
    /// Class for lectures
    /// </summary>
    class Lecture : Material
    {
        public string Text { get; set; }
        private const int TextMaxLength = 100000;

        public string Uri { get; set; }
        public string PresentationType { get; set; }

        public List<Seminar> ListOfSeminarsForThisLecture = new List<Seminar>();
        public List<Labwork> ListOfLabworksForThisLecture = new List<Labwork>();
        private static readonly string[] PresentationsAllTypes = {"PPT", "PDF"};

        /// <summary>
        /// Constructor for the lecture
        /// </summary>
        /// <param name="text">Text of the lecture</param>
        /// <param name="uri">Uri of the lecture</param>
        /// <param name="presentationType">Presentation type of the lecture, "unknown" by default</param>
        /// <param name="description">Description, null by default</param>
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

        /// <inheritdoc />
        public override object Clone()
        {
            var seminarsListCopy = new List<Seminar>();
            var labworksListCopy = new List<Labwork>();
            foreach (var material in ListOfSeminarsForThisLecture)
            {
                seminarsListCopy.Add(material);
            }

            foreach (var material in ListOfLabworksForThisLecture)
            {
                labworksListCopy.Add(material);
            }

            return new Lecture(Text, Uri)
            {
                ListOfSeminarsForThisLecture = seminarsListCopy,
                ListOfLabworksForThisLecture = labworksListCopy,
                PresentationType = PresentationType,
                Data = {Description = Data.Description, EntityGuid = Data.EntityGuid}
            };
        }
    }
}