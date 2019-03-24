using System;
using System.Collections.Generic;
using System.Linq;

namespace DEV_4
{

    class Lecture : Material
    {
        public string Text { get; set; } //TODO placeholder for now, char.limit figure out how
        public string URI { get; set; }
        public string PresentationType { get; set; }
        private List<Seminar> seminarsList;
        private List<Labwork> labworksList;
        private static readonly string[] presentationsAllTypes = {"Unknown", "PPT", "PDF"};

        public Lecture(string name, string description /*todo stuff here*/) : base(name, description)
        {

        }
    }
}
