using System.Collections.Generic;

namespace DEV_6
{
    /// <summary>
    /// The command to count average price.
    /// </summary>
    internal class CommandCountAveragePrice : ICommand
    {
        /// <summary>
        /// The receiver.
        /// </summary>
        private CounterAveragePrice counter;

        /// <summary>
        /// The list of cars with their info.
        /// </summary>
        private List<CarInfoStruct> listOfCars;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandCountAveragePrice"/> class.
        /// </summary>
        /// <param name="receiver">
        /// The receiver.
        /// </param>
        /// <param name="listOfCars">
        /// The list of cars with their info.
        /// </param>
        public CommandCountAveragePrice(CounterAveragePrice receiver, List<CarInfoStruct> listOfCars)
        {
            this.counter = receiver;
            this.listOfCars = listOfCars;
        }

        /// <inheritdoc />
        public double Execute()
        {
            return this.counter.CountAveragePrice(this.listOfCars);
        }
    }
}