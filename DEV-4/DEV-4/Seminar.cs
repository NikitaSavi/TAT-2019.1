using System.Collections.Generic;

namespace DEV_4
{
    /// <summary>
    /// Class for seminars
    /// </summary>
    class Seminar : Material
    {
        public List<string> TasksList { get; set; }
        public Dictionary<string, string> Questions { get; set; }

        /// <summary>
        /// Constructor for seminars
        /// </summary>
        /// <param name="tasksList">List of tasks for the seminars</param>
        /// <param name="questions"></param>
        /// <param name="description"></param>
        public Seminar(List<string> tasksList, Dictionary<string, string> questions, string description = null) :
            base(description)
        {
            TasksList = tasksList;
            Questions = questions;
        }

        /// <inheritdoc />
        public override object Clone()
        {
            var tasksListCopy = new List<string>();
            var questionsCopy = new Dictionary<string, string>();
            foreach (var task in TasksList)
            {
                tasksListCopy.Add(task);
            }

            foreach (var task in Questions)
            {
                questionsCopy.Add(task.Key, task.Value);
            }

            return new Seminar(tasksListCopy, questionsCopy)
            {
                Data = {Description = Data.Description, EntityGuid = Data.EntityGuid}
            };
        }
    }
}