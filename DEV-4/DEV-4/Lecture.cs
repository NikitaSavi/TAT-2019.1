using System.Collections.Generic;

namespace DEV_4
{
    /// <summary>
    /// Class for lectures
    /// </summary>
    public class Lecture : Material
    {
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The text max length.
        /// </summary>
        private const int TextMaxLength = 100000;

        /// <summary>
        /// The list of seminars for this lecture.
        /// </summary>
        public List<Seminar> ListOfSeminarsForThisLecture { get; set; }

        /// <summary>
        /// The list of labworks for this lecture.
        /// </summary>
        public List<Labwork> ListOfLabworksForThisLecture { get; set; }

        /// <summary>
        /// Gets or sets the presentation.
        /// </summary>
        private Presentation Presentation { get; set; }

        /// <summary>
        /// Constructor for lecture
        /// </summary>
        /// <param name="text">Text of the lecture</param>
        /// <param name="presentation">Presentation material for the lecture</param>
        /// <param name="description">Description, null by default</param>
        public Lecture(string text, Presentation presentation, string description = null)
            : base(description)
        {
            this.ListOfSeminarsForThisLecture = new List<Seminar>();
            this.ListOfLabworksForThisLecture = new List<Labwork>();
            this.Presentation = presentation;
            this.Text = text.WithMaxLength(TextMaxLength);
        }

        /// <inheritdoc />
        public override object Clone()
        {
            var seminarsListCopy = new List<Seminar>();
            var labworksListCopy = new List<Labwork>();
            foreach (var material in this.ListOfSeminarsForThisLecture)
            {
                seminarsListCopy.Add(material);
            }

            foreach (var material in this.ListOfLabworksForThisLecture)
            {
                labworksListCopy.Add(material);
            }

            return new Lecture(this.Text, Presentation)
                       {
                           ListOfSeminarsForThisLecture = seminarsListCopy,
                           ListOfLabworksForThisLecture = labworksListCopy,
                           Data = { Description = Data.Description, EntityGuid = Data.EntityGuid }
                       };
        }
    }
}