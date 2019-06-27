using System.Collections.Generic;
using DEV_6.CommandsReceivers;
using DEV_6.Database;

namespace DEV_6.Commands
{
    /// <summary>
    /// The command to count average price of a certain type.
    /// </summary>
    public class CommandCountAveragePriceOfBrand : ICommand
    {
        /// <summary>
        /// The receiver.
        /// </summary>
        private CounterAveragePriceOfBrand counter;

        /// <summary>
        /// The type of a vehicle.
        /// </summary>
        private string brand;

        /// <summary>
        /// The list of vehicles with their info.
        /// </summary>
        private List<VehicleInfoStruct> listOfVehicles;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandCountAveragePriceOfBrand"/> class.
        /// </summary>
        /// <param name="receiver">
        /// The receiver.
        /// </param>
        /// <param name="listOfVehicles">
        /// The list of vehicles with their info.
        /// </param>
        /// <param name="brand">
        /// The brand of a vehicle.
        /// </param>
        public CommandCountAveragePriceOfBrand(CounterAveragePriceOfBrand receiver, List<VehicleInfoStruct> listOfVehicles, string brand)
        {
            this.counter = receiver;
            this.brand = brand;
            this.listOfVehicles = listOfVehicles;
        }

        /// <inheritdoc />
        public double Execute() => this.counter.CountAveragePrice(this.listOfVehicles, this.brand);
    }
}