using System.Collections.Generic;

namespace DEV_4
{
    class Discipline
    {
        private readonly EntityData _data;

        public List<Lecture> ListOfLectures = new List<Lecture>();
        public List<Seminar> ListOfSeminars = new List<Seminar>();
        public List<Labwork> ListOfLabworks = new List<Labwork>();

        public Discipline(string description = null)
        {
            _data = new EntityData(description);
        }

        //TODO elaborate on the task
        public List<Material> this[int index]
        {
            get
            {
                var materials = new List<Material> {ListOfLectures[index]};
                if (ListOfLectures[index].ListOfSeminarsToThisLecture.Count != 0)
                {
                    materials.AddRange(ListOfLectures[index].ListOfSeminarsToThisLecture);
                }

                if (ListOfLectures[index].ListOfLabworksToThisLecture.Count != 0)
                {
                    materials.AddRange(ListOfLectures[index].ListOfLabworksToThisLecture);
                }

                return materials;
            }
        }

        //TODO maybe some other way would be better?
        public void AddLecture(string text, string uri, string presentationType = "Unknown", string description = null)
        {
            ListOfLectures.Add(new Lecture(text, uri, presentationType, description));
        }

        //TODO really need to rewrite this
        public void AddSeminar(string[] tasksList, string description = null, Lecture connectedLecture = null)
        {
            var seminar = new Seminar(tasksList, description);
            ListOfSeminars.Add(seminar);
            ListOfLectures[ListOfLectures.IndexOf(connectedLecture)].ListOfSeminarsToThisLecture.Add(seminar);
        }

        //TODO really need to rewrite this
        public void AddLabwork(string description = null, Labwork connectedLabwork = null)
        {
            var labwork = new Labwork(description);
            ListOfLabworks.Add(labwork);
            ListOfLectures[ListOfLabworks.IndexOf(connectedLabwork)].ListOfLabworksToThisLecture.Add(labwork);
        }

        public override string ToString()
        {
            return string.IsNullOrEmpty(_data.Description) ? "No description" : _data.Description;
        }

        public bool Equals(Discipline obj)
        {
            return _data.EntityGuid.Equals(obj._data.EntityGuid);
        }
    }
}