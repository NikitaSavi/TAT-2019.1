using System.Collections.Generic;

namespace DEV_4
{
    class Seminar : Material
    {
        //TODO init stuff below - constructor or method?
        public string[] TasksList { get; set; }

        public Dictionary<string, string> Questions { get; set; } = new Dictionary<string, string>();

        /*TODO how to send Q&A?*/
        public Seminar(string[] tasksList, string description = null) : base(description)
        {
            TasksList = tasksList;
        }
    }
}