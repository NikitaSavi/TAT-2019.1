using System;
using System.Collections.Generic;

namespace DEV_6
{
    using System.Linq;

    /// <summary>
    /// Counts the average price of certain mark.
    /// </summary>
    public class CounterAveragePriceOfMark
    {
        /// <summary>
        /// Counts the average price of a mark.
        /// </summary>
        /// <param name="listOfVehicles">
        /// The list of vehicles with their info.
        /// </param>
        /// <param name="mark">
        /// Mark of the vehicle
        /// </param>
        /// <returns>
        /// The average price of the mark.
        /// </returns>
        public double CountAveragePrice(List<VehicleInfoStruct> listOfVehicles, string mark) =>
            Math.Round(
                (double)listOfVehicles.Where(x => x.Mark == mark).Sum(x => x.Price)
                / listOfVehicles.Count(x => x.Mark == mark),
                3);
    }
}