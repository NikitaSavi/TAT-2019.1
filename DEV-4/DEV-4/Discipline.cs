using System.Collections.Generic;
using System.Linq;

namespace DEV_4
{
    class Discipline
    {
        private readonly EntityData _data;

        public Dictionary<Lecture, Material[]> ListOfMaterials = new Dictionary<Lecture, Material[]>();
        public List<Lecture> ListOfLectures = new List<Lecture>();

        public Discipline(string description = null)
        {
            _data = new EntityData(description);
        }
        //TODO elaborate on the task
        public List<Material> this[int index]
        {
            get
            {
                List<Material> materials=new List<Material>();
                materials.Add(ListOfLectures[index]);
                materials.AddRange(ListOfMaterials[ListOfLectures[index]]);
                return materials;
            }
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