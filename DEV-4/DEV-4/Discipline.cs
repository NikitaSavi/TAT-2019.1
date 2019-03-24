using System.Collections.Generic;

namespace DEV_4
{
    class Discipline
    {
        private readonly EntityData _data;

        //TODO things below aren't final
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
                return materials;
            }
        }
        //TODO maybe some other way would be better?
        public void AddLecture(string text, string uri, string presentationType = "Unknown", string description = null)
        {
            ListOfLectures.Add(new Lecture(text, uri, presentationType, description));
        }

        public void AddSeminar(string[] tasksList, string description = null)
        {
            ListOfSeminars.Add(new Seminar(tasksList, description));
        }

        public void AddLabwork(string description = null)
        {
            ListOfLabworks.Add(new Labwork(description));
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