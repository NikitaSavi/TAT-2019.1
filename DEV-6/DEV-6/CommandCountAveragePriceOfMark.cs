using System.Collections.Generic;

namespace DEV_6
{
    /// <summary>
    /// The command to count average price of a certain type.
    /// </summary>
    internal class CommandCountAveragePriceOfMark : ICommand
    {
        /// <summary>
        /// The receiver.
        /// </summary>
        private CounterAveragePriceOfMark counter;

        /// <summary>
        /// The type of a car.
        /// </summary>
        private string mark;

        /// <summary>
        /// The list of cars with their info.
        /// </summary>
        private List<CarInfoStruct> listOfCars;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandCountAveragePriceOfMark"/> class.
        /// </summary>
        /// <param name="receiver">
        /// The receiver.
        /// </param>
        /// <param name="listOfCars">
        /// The list of cars with their info.
        /// </param>
        /// <param name="mark">
        /// The mark of a car.
        /// </param>
        public CommandCountAveragePriceOfMark(CounterAveragePriceOfMark receiver, List<CarInfoStruct> listOfCars, string mark)
        {
            this.counter = receiver;
            this.mark = mark;
            this.listOfCars = listOfCars;
        }

        /// <inheritdoc />
        public double Execute()
        {
           return this.counter.CountAveragePrice(this.listOfCars, this.mark);
        }
    }
}