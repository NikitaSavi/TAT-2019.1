using System;
using System.Collections.Generic;

namespace DEV_4
{
    /// <summary>
    /// Class for disciplines
    /// </summary>
    public class Discipline : ICloneable
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        public EntityData Data { get; set; }

        /// <summary>
        /// The list of lectures.
        /// </summary>
        public List<Lecture> ListOfLectures { get; set; }

        /// <summary>
        /// The list of seminars.
        /// </summary>
        public List<Seminar> ListOfSeminars { get; set; }

        /// <summary>
        /// The list of labworks.
        /// </summary>
        public List<Labwork> ListOfLabworks { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Discipline"/> class.
        /// </summary>
        /// <param name="description">
        /// The description.
        /// </param>
        public Discipline(string description = null)
        {
            this.ListOfLectures = new List<Lecture>();
            this.ListOfSeminars = new List<Seminar>();
            this.ListOfLabworks = new List<Labwork>();
            this.Data = new EntityData(description);
        }

        /// <summary>
        /// Indexer to get lectures and complementary materials of the discipline
        /// </summary>
        /// <param name="index">Index of the lecture in the ListOfLectures</param>
        /// <returns>List containing the necessary lectures plus all seminars and labs for it</returns>
        public IEnumerable<Material> this[int index]
        {
            get
            {
                var materials = new List<Material> { this.ListOfLectures[index] };
                if (this.ListOfLectures[index].ListOfSeminarsForThisLecture.Count != 0)
                {
                    materials.AddRange(this.ListOfLectures[index].ListOfSeminarsForThisLecture);
                }

                if (this.ListOfLectures[index].ListOfLabworksForThisLecture.Count != 0)
                {
                    materials.AddRange(this.ListOfLectures[index].ListOfLabworksForThisLecture);
                }

                return materials;
            }
        }

        /// <summary>
        /// Adds lecture to the discipline
        /// </summary>
        /// <param name="lecture">Lecture to add</param>
        public void AddLecture(Lecture lecture) => this.ListOfLectures.Add(lecture);

        /// <summary>
        /// Adds seminar to the discipline (and to a lecture if necessary)
        /// </summary>
        /// <param name="seminar">Seminar to add</param>
        /// <param name="connectedLecture">Lecture to connect the seminar with</param>
        public void AddSeminar(Seminar seminar, Lecture connectedLecture = null)
        {
            this.ListOfSeminars.Add(seminar);
            if (connectedLecture != null)
            {
                this.ListOfLectures[this.ListOfLectures.IndexOf(connectedLecture)].ListOfSeminarsForThisLecture
                    .Add(seminar);
            }
        }

        /// <summary>
        /// Adds labwork to the discipline (and to a lecture if necessary)
        /// </summary>
        /// <param name="labwork">Labwork to add</param>
        /// <param name="connectedLecture">Lecture to connect the labwork with</param>
        public void AddLabwork(Labwork labwork, Lecture connectedLecture = null)
        {
            this.ListOfLabworks.Add(labwork);
            if (connectedLecture != null)
            {
                this.ListOfLectures[this.ListOfLectures.IndexOf(connectedLecture)].ListOfLabworksForThisLecture
                    .Add(labwork);
            }
        }

        /// <summary>
        /// Override method to return description of an entity
        /// </summary>
        /// <returns>Description of an entity</returns>
        public override string ToString() =>
            string.IsNullOrEmpty(this.Data.Description) ? "No description available" : $"Description: {this.Data.Description}";

        /// <summary>
        /// Override method for comparing entities. Entities are equal if their GUIDs are equal
        /// </summary>
        /// <param name="obj">An entity to check equality with</param>
        /// <returns>True if received entity has the same GUID</returns>
        public override bool Equals(object obj) => obj is Discipline discipline && this.Data.EntityGuid == discipline.Data.EntityGuid;

        /// <summary>
        /// Performs deep cloning of an entity
        /// </summary>
        /// <returns>A clone of an entity</returns>
        public object Clone()
        {
            var lecturesCopy = new List<Lecture>();
            var seminarsCopy = new List<Seminar>();
            var labworksCopy = new List<Labwork>();

            foreach (var material in this.ListOfLectures)
            {
                lecturesCopy.Add(material);
            }

            foreach (var material in this.ListOfSeminars)
            {
                seminarsCopy.Add(material);
            }

            foreach (var material in this.ListOfLabworks)
            {
                labworksCopy.Add(material);
            }

            return new Discipline
                       {
                           Data = { Description = this.Data.Description, EntityGuid = this.Data.EntityGuid },
                           ListOfLectures = lecturesCopy,
                           ListOfSeminars = seminarsCopy,
                           ListOfLabworks = labworksCopy,
                       };
        }
    }
}