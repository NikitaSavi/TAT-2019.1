using System;
using System.Collections.Generic;
using System.Linq;

namespace DEV_6
{ 
    /// <summary>
    /// Counts the average price of cars.
    /// </summary>
    internal class CounterAveragePrice
    {
        /// <summary>
        /// Counts the average price of cars.
        /// </summary>
        /// <param name="listOfCars">
        /// The list of cars with their info.
        /// </param>
        /// <returns>
        /// The average price.
        /// </returns>
        public double CountAveragePrice(List<CarInfoStruct> listOfCars) => Math.Round((double)listOfCars.Sum(x => x.Price) / listOfCars.Count, 2);
    }
}