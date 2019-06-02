using System.Collections.Generic;
using DEV_6.CommandsReceivers;
using DEV_6.Database;

namespace DEV_6.Commands
{
    /// <summary>
    /// The command to count all vehicles.
    /// </summary>
    public class CommandCountAllVehicles : ICommand
    {
        /// <summary>
        /// The receiver.
        /// </summary>
        private CounterAllVehicles counter;

        /// <summary>
        /// The list of vehicles with their info.
        /// </summary>
        private List<VehicleInfoStruct> listOfVehicles;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandCountAllVehicles"/> class.
        /// </summary>
        /// <param name="receiver">
        /// The receiver.
        /// </param>
        /// <param name="listOfVehicles">
        /// The list of vehicles with their info.
        /// </param>
        public CommandCountAllVehicles(CounterAllVehicles receiver, List<VehicleInfoStruct> listOfVehicles)
        {
            this.counter = receiver;
            this.listOfVehicles = listOfVehicles;
        }

        /// <inheritdoc />
        public double Execute() => this.counter.CountAllVehicles(this.listOfVehicles);
    }
}