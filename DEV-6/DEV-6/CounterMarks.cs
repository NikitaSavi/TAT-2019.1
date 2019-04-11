﻿using System.Collections.Generic;

namespace DEV_6
{
    using System.Linq;

    /// <summary>
    /// Counts the amount of marks.
    /// </summary>
    public class CounterMarks
    {
        /// <summary>
        /// Counts the amount of marks.
        /// </summary>
        /// <param name="listOfVehicles">
        /// The list of vehicles with their info.
        /// </param>
        /// <returns>
        /// The amount of marks.
        /// </returns>
        public double CountMarks(List<VehicleInfoStruct> listOfVehicles) => listOfVehicles.Select(x => x.Mark).Distinct().Count();
    }
}