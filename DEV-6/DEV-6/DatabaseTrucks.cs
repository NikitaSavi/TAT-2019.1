using System.Collections.Generic;

namespace DEV_6
{
    /// <summary>
    /// The trucks database.
    /// </summary>
    public class DatabaseTrucks
    {
        /// <summary>
        /// The instance of the Singleton-type class.
        /// </summary>
        private static DatabaseTrucks instance;

        /// <summary>
        /// Gets or sets the list of trucks.
        /// </summary>
        public List<VehicleInfoStruct> ListOfTrucks { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseTrucks"/> class. 
        /// </summary>
        /// <param name="xDocName">
        /// Name of XML doc with trucks info.
        /// </param>
        private DatabaseTrucks(string xDocName)
        {
            this.ListOfTrucks = XmlParser.ParseVehicleInfo(xDocName);
        }

        /// <summary>
        /// Returns the instance of the class, or creates it if it doesn't exist
        /// </summary>
        /// <param name="xDocName">
        /// Name of XML doc with trucks info.
        /// </param>
        /// <returns>
        /// The <see cref="DatabaseTrucks"/>.
        /// </returns>
        public static DatabaseTrucks GetDatabaseTrucks(string xDocName) => instance ?? (instance = new DatabaseTrucks(xDocName));
    }
}
