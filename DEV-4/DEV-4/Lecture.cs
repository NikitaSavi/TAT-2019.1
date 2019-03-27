using System.Collections.Generic;

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
        public List<Seminar> ListOfSeminarsForThisLecture = new List<Seminar>();
        public List<Labwork> ListOfLabworksForThisLecture = new List<Labwork>();

        public enum PresentationAllTypes
        {
            Unknown,
            PPT,
            PDF
        }

        public PresentationAllTypes PresentationType;

        /// <summary>
        /// Constructor for lecture
        /// </summary>
        /// <param name="text">Text of the lecture</param>
        /// <param name="uri">Uri for presentation</param>
        /// <param name="presentationType">Type of presentation</param>
        /// <param name="description">Description, null by default</param>
        public Lecture(string text, string uri, PresentationAllTypes presentationType = PresentationAllTypes.Unknown,
            string description = null) : base(description)
        {
            Text = text.WithMaxLength(TextMaxLength);
            Uri = uri;
            PresentationType = presentationType;
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