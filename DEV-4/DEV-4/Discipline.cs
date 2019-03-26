using System;
using System.Collections.Generic;

namespace DEV_4
{
    /// <summary>
    /// Class for disciplines
    /// </summary>
    class Discipline : ICloneable
    {
        public EntityData Data { get; set; }

        public List<Lecture> ListOfLectures = new List<Lecture>();
        public List<Seminar> ListOfSeminars = new List<Seminar>();
        public List<Labwork> ListOfLabworks = new List<Labwork>();

        /// <summary>
        /// Base constructor for materials, sets general data
        /// </summary>
        /// <param name="description">Description of an entity, null by default</param>
        public Discipline(string description = null)
        {
            Data = new EntityData(description);
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
                var materials = new List<Material> {ListOfLectures[index]};
                if (ListOfLectures[index].ListOfSeminarsForThisLecture.Count != 0)
                {
                    materials.AddRange(ListOfLectures[index].ListOfSeminarsForThisLecture);
                }

                if (ListOfLectures[index].ListOfLabworksForThisLecture.Count != 0)
                {
                    materials.AddRange(ListOfLectures[index].ListOfLabworksForThisLecture);
                }

                return materials;
            }
        }

        /// <summary>
        /// Adds lecture to the discipline
        /// </summary>
        /// <param name="lecture">Lecture to add</param>
        public void AddLecture(Lecture lecture)
        {
            ListOfLectures.Add(lecture);
        }

        /// <summary>
        /// Adds seminar to the discipline (and to a lecture if necessary)
        /// </summary>
        /// <param name="seminar">Seminar to add</param>
        /// <param name="connectedLecture">Lecture to connect the seminar with</param>
        public void AddSeminar(Seminar seminar, Lecture connectedLecture = null)
        {
            ListOfSeminars.Add(seminar);
            if (connectedLecture != null)
            {
                ListOfLectures[ListOfLectures.IndexOf(connectedLecture)].ListOfSeminarsForThisLecture.Add(seminar);
            }
        }

        /// <summary>
        /// Adds labwork to the discipline (and to a lecture if necessary)
        /// </summary>
        /// <param name="seminar">Labwork to add</param>
        /// <param name="connectedLecture">Lecture to connect the labwork with</param>
        public void AddLabwork(Labwork labwork, Lecture connectedLecture = null)
        {
            ListOfLabworks.Add(labwork);
            if (connectedLecture != null)
            {
                ListOfLectures[ListOfLectures.IndexOf(connectedLecture)].ListOfLabworksForThisLecture.Add(labwork);
            }
        }

        /// <summary>
        /// Override method to return description of an entity
        /// </summary>
        /// <returns>Description of an entity</returns>
        public override string ToString()
        {
            return string.IsNullOrEmpty(Data.Description)
                ? "No description available"
                : $"Description: {Data.Description}";
        }

        /// <summary>
        /// Override method for comparing entities. Entities are equal if their GUIDs are equal
        /// </summary>
        /// <param name="obj">An entity to check equality with</param>
        /// <returns>True if received entity has the same GUID</returns>
        public override bool Equals(object obj)
        {
            if (obj is Discipline discipline)
            {
                return (Data.EntityGuid == discipline.Data.EntityGuid);
            }

            return false;
        }

        /// <summary>
        /// Performs deep cloning of an entity
        /// </summary>
        /// <returns>A clone of an entity</returns>
        public object Clone()
        {
            var lecturesCopy = new List<Lecture>();
            var seminarsCopy = new List<Seminar>();
            var labworksCopy = new List<Labwork>();

            foreach (var material in ListOfLectures)
            {
                lecturesCopy.Add(material);
            }

            foreach (var material in ListOfSeminars)
            {
                seminarsCopy.Add(material);
            }

            foreach (var material in ListOfLabworks)
            {
                labworksCopy.Add(material);
            }

            return new Discipline
            {
                Data = {Description = Data.Description, EntityGuid = Data.EntityGuid},
                ListOfLectures = lecturesCopy,
                ListOfSeminars = seminarsCopy,
                ListOfLabworks = labworksCopy,
            };
        }
    }
}