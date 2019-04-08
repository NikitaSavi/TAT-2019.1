using System.Collections.Generic;
using System.Linq;

namespace DEV_6
{
    /// <summary>
    /// Counts the amount of cars.
    /// </summary>
    internal class CounterAllCars
    {
        /// <summary>
        /// Counts the amount of cars.
        /// </summary>
        /// <param name="listOfCars">
        /// The list of cars with their info.
        /// </param>
        /// <returns>
        /// The amount of cars.
        /// </returns>
        public double CountAllCars(List<CarInfoStruct> listOfCars) => listOfCars.Sum(x => x.Quantity);
    }
}