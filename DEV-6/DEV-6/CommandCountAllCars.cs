using System.Collections.Generic;

namespace DEV_6
{
    /// <summary>
    /// The command to count all cars.
    /// </summary>
    internal class CommandCountAllCars : ICommand
    {
        /// <summary>
        /// The receiver.
        /// </summary>
        private CounterAllCars counter;

        /// <summary>
        /// The list of cars with their info.
        /// </summary>
        private List<CarInfoStruct> listOfCars;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandCountAllCars"/> class.
        /// </summary>
        /// <param name="receiver">
        /// The receiver.
        /// </param>
        /// <param name="listOfCars">
        /// The list of cars with their info.
        /// </param>
        public CommandCountAllCars(CounterAllCars receiver, List<CarInfoStruct> listOfCars)
        {
            this.counter = receiver;
            this.listOfCars = listOfCars;
        }

        /// <inheritdoc />
        public double Execute()
        {
            return this.counter.CountAllCars(this.listOfCars);
        }
    }
}