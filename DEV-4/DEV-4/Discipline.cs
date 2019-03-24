using System;
using System.Collections.Generic;

namespace DEV_4
{
    class Discipline
    {
        private readonly EntityData _data;
        private List<Material> _listOfMaterials;

        public Discipline(string name, string description = null)
        {
            _data=new EntityData(name, description);
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