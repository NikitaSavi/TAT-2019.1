using System.Collections.Generic;

namespace DEV_6
{
    using System.Linq;

    /// <summary>
    /// Counts the amount of marks.
    /// </summary>
    internal class CounterMarks
    {
        /// <summary>
        /// Counts the amount of marks.
        /// </summary>
        /// <param name="listOfCars">
        /// The list of cars with their info.
        /// </param>
        /// <returns>
        /// The amount of marks.
        /// </returns>
        public double CountMarks(List<CarInfoStruct> listOfCars) => listOfCars.Select(x => x.Mark).Distinct().Count();
    }
}