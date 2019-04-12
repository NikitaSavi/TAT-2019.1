using System;
using System.Collections.Generic;
using System.Linq;
using DEV_6.Database;

namespace DEV_6.CommandsReceivers
{
    /// <summary>
    /// Counts the average price of certain brand.
    /// </summary>
    public class CounterAveragePriceOfBrand
    {
        /// <summary>
        /// Counts the average price of a brand.
        /// </summary>
        /// <param name="listOfVehicles">
        /// The list of vehicles with their info.
        /// </param>
        /// <param name="brand">
        /// brand of the vehicle
        /// </param>
        /// <returns>
        /// The average price of the brand.
        /// </returns>
        public double CountAveragePrice(List<VehicleInfoStruct> listOfVehicles, string brand) =>
            Math.Round(
                (double)listOfVehicles.Where(x => x.Brand == brand).Sum(x => x.Price)
                / listOfVehicles.Count(x => x.Brand == brand),
                3);
    }
}