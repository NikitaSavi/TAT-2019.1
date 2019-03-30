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
        public List<Seminar> ListOfSeminarsForThisLecture = new List<Seminar>();
        public List<Labwork> ListOfLabworksForThisLecture = new List<Labwork>();
        private Presentation Presentation { get; set; }

        /// <summary>
        /// Constructor for lecture
        /// </summary>
        /// <param name="text">Text of the lecture</param>
        /// <param name="presentation">Presentation material for the lecture</param>
        /// <param name="description">Description, null by default</param>
        public Lecture(string text, Presentation presentation, string description = null) : base(description)
        {
            Presentation = presentation;
            Text = text.WithMaxLength(TextMaxLength);
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

            return new Lecture(Text, Presentation)
            {
                ListOfSeminarsForThisLecture = seminarsListCopy,
                ListOfLabworksForThisLecture = labworksListCopy,
                Data = {Description = Data.Description, EntityGuid = Data.EntityGuid}
            };
        }
    }
}