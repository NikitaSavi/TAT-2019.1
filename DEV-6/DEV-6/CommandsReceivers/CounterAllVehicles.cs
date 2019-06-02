using System.Collections.Generic;
using System.Linq;
using DEV_6.Database;

namespace DEV_6.CommandsReceivers
{
    /// <summary>
    /// Counts the amount of vehicles.
    /// </summary>
    public class CounterAllVehicles
    {
        /// <summary>
        /// Counts the amount of vehicles.
        /// </summary>
        /// <param name="listOfVehicles">
        /// The list of vehicles with their info.
        /// </param>
        /// <returns>
        /// The amount of vehicles.
        /// </returns>
        public double CountAllVehicles(List<VehicleInfoStruct> listOfVehicles) => listOfVehicles.Sum(x => x.Quantity);
    }
}