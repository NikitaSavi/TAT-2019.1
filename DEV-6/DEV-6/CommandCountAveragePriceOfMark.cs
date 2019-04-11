using System.Collections.Generic;

namespace DEV_6
{
    /// <summary>
    /// The command to count average price of a certain type.
    /// </summary>
    public class CommandCountAveragePriceOfMark : ICommand
    {
        /// <summary>
        /// The receiver.
        /// </summary>
        private CounterAveragePriceOfMark counter;

        /// <summary>
        /// The type of a vehicle.
        /// </summary>
        private string mark;

        /// <summary>
        /// The list of vehicles with their info.
        /// </summary>
        private List<VehicleInfoStruct> listOfVehicles;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandCountAveragePriceOfMark"/> class.
        /// </summary>
        /// <param name="receiver">
        /// The receiver.
        /// </param>
        /// <param name="listOfVehicles">
        /// The list of vehicles with their info.
        /// </param>
        /// <param name="mark">
        /// The mark of a vehicle.
        /// </param>
        public CommandCountAveragePriceOfMark(CounterAveragePriceOfMark receiver, List<VehicleInfoStruct> listOfVehicles, string mark)
        {
            this.counter = receiver;
            this.mark = mark;
            this.listOfVehicles = listOfVehicles;
        }

        /// <inheritdoc />
        public double Execute() => this.counter.CountAveragePrice(this.listOfVehicles, this.mark);
    }
}