using System.Collections.Generic;
using System.Linq;

namespace DEV_4
{
    /// <summary>
    /// Class for seminars
    /// </summary>
    public class Seminar : Material
    {
        /// <summary>
        /// Gets or sets the tasks list.
        /// </summary>
        public List<string> TasksList { get; set; }

        /// <summary>
        /// Gets or sets the questions.
        /// </summary>
        public Dictionary<string, string> Questions { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Seminar"/> class.
        /// </summary>
        /// <param name="tasksList">
        /// The tasks list.
        /// </param>
        /// <param name="questions">
        /// The questions.
        /// </param>
        /// <param name="description">
        /// The description.
        /// </param>
        public Seminar(List<string> tasksList, Dictionary<string, string> questions, string description = null)
            : base(description)
        {
            this.TasksList = tasksList;
            this.Questions = questions;
        }

        /// <inheritdoc />
        public override object Clone()
        {
            var tasksListCopy = this.TasksList.ToList();
            var questionsCopy = this.Questions.ToDictionary(task => task.Key, task => task.Value);

            return new Seminar(tasksListCopy, questionsCopy)
            {
                Data = {Description = Data.Description, EntityGuid = Data.EntityGuid}
            };
        }
    }
}