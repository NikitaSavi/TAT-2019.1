using System.Collections.Generic;

namespace DEV_4
{
    /// <summary>
    /// Class for lectures
    /// </summary>
    class Lecture : Material
    {
        public List<Seminar> ListOfSeminarsForThisLecture = new List<Seminar>();
        public List<Labwork> ListOfLabworksForThisLecture = new List<Labwork>();
        private Presentation presentation;

        /// <summary>
        /// Constructor for lecture
        /// </summary>
        /// <param name="text">Text of the lecture</param>
        /// <param name="uri">Uri for presentation</param>
        /// <param name="presentationType">Type of presentation</param>
        /// <param name="description">Description, null by default</param>
        public Lecture(Presentation presentation, string description = null) : base(description)
        {

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

            return new Lecture(presentation)
            {
                ListOfSeminarsForThisLecture = seminarsListCopy,
                ListOfLabworksForThisLecture = labworksListCopy,
                presentation = presentation,
                Data = {Description = Data.Description, EntityGuid = Data.EntityGuid}
            };
        }
    }
}