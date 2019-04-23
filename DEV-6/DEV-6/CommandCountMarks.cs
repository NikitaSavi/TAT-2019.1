using System.Collections.Generic;

namespace DEV_6
{
    /// <summary>
    /// The command to count marks.
    /// </summary>
    internal class CommandCountMarks : ICommand
    {
        /// <summary>
        /// The receiver.
        /// </summary>
        private CounterMarks counter;

        /// <summary>
        /// The list of cars with their info.
        /// </summary>
        private List<CarInfoStruct> listOfCars;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandCountMarks"/> class.
        /// </summary>
        /// <param name="receiver">
        /// The receiver.
        /// </param>
        /// <param name="listOfCars">
        /// The list of cars with their info.
        /// </param>
        public CommandCountMarks(CounterMarks receiver, List<CarInfoStruct> listOfCars)
        {
            this.counter = receiver;
            this.listOfCars = listOfCars;
        }

        /// <inheritdoc />
        public double Execute()
        {
            return this.counter.CountMarks(this.listOfCars);
        }
    }
}