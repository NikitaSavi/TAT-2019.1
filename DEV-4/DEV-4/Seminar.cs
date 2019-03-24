using System.Collections.Generic;

namespace DEV_4
{
    class Seminar : Material
    {
        //TODO should they be private or public?
        //TODO let's pretend for now that "set of tasks" is just a list containing numbers of task from some textbook
        public List<int> TasksList { get; set; } = new List<int>();
        public Dictionary<string, string> Questions { get; set; } = new Dictionary<string, string>();

        public Seminar(string description = null) : base(description)
        {
            //TODO ?
        }
    }
}