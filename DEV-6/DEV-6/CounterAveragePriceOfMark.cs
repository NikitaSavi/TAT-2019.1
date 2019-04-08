using System;
using System.Collections.Generic;

namespace DEV_6
{
    using System.Linq;

    /// <summary>
    /// Counts the average price of certain mark.
    /// </summary>
    internal class CounterAveragePriceOfMark
    {
        /// <summary>
        /// Counts the average price of a mark.
        /// </summary>
        /// <param name="listOfCars">
        /// The list of cars with their info.
        /// </param>
        /// <param name="mark">
        /// Mark of the car
        /// </param>
        /// <returns>
        /// The average price of the mark.
        /// </returns>
        public double CountAveragePrice(List<CarInfoStruct> listOfCars, string mark) =>
            Math.Round(
                (double)listOfCars.Where(x => x.Mark == mark).Sum(x => x.Price)
                / listOfCars.Count(x => x.Mark == mark),
                2);
    }
}