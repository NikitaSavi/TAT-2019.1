using System;
using System.Collections.Generic;

namespace DEV_4
{
    class Discipline
    {
        private readonly EntityData Data;
        public List<Material> ListOfMaterials { get; set; }

        public Discipline(string name, string description)
        {
            Data=new EntityData(name, description);
        }

        public override string ToString()
        {
            return string.IsNullOrEmpty(Data.Description) ? "No description" : Data.Description;
        }

        public bool Equals(Discipline obj)
        {
            return Data.Guid.Equals(obj.Data.Guid);
        }
    }
}