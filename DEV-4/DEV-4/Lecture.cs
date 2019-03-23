using System;
using System.Linq;

namespace DEV_4
{

    class Lecture : Material
    {
        public string Text { get; set; } //TODO placeholder for now, char.limit figure out how
        public string URI { get; set; }
        public string PresentationType { get; set; }
        private static readonly string[] presentationsAllTypes = {"Unknown", "PPT", "PDF"};
        //TODO need to assign name+descr (base class) and text+uri+pres.type, need a better solution
        //public Lecture(string text, string uri, string presentationType) 
        //{
        //    Text = text;
        //    if (presentationsAllTypes.Contains(presentationType))
        //    {
        //        PresentationType = presentationType;
        //    }
        //    else throw new Exception("Wrong presentation type");
        //}
    }
}
