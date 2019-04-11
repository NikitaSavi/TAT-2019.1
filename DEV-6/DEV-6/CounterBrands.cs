using System.Collections.Generic;

namespace DEV_6
{
    using System.Linq;

    /// <summary>
    /// Counts the amount of brands.
    /// </summary>
    public class CounterBrands
    {
        /// <summary>
        /// Counts the amount of brands.
        /// </summary>
        /// <param name="listOfVehicles">
        /// The list of vehicles with their info.
        /// </param>
        /// <returns>
        /// The amount of brands.
        /// </returns>
        public double CountBrands(List<VehicleInfoStruct> listOfVehicles) => listOfVehicles.Select(x => x.Brand).Distinct().Count();
    }
}