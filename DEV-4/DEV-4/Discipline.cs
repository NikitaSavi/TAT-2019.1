using System.Collections.Generic;

namespace DEV_4
{
    class Discipline
    {
        public string Name { get; set; }
        public string GUID { get; set; }
        public string Description { get; set; }
        private List<Material> listOfMaterials;//TODO get set how

        public Discipline(string name, string description) //TODO description: maybe a better way to set it exists?
        {
            Name = name;
            Description = description;//TODO 256 symbols restriction, find how to implement (simple substring or better?)
        }
    }
} 