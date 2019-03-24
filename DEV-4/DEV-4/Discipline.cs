using System.Collections.Generic;

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
                var materials = new List<Material> {ListOfLectures[index]};
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