using System;
using System.Collections.Generic;
using System.Xml;

namespace DEV_6
{
    /// <summary>
    /// XML Parser for car information.
    /// </summary>
    internal static class XmlParser
    {
        /// <summary>
        /// Parse info about cars from the XML doc to a list.
        /// </summary>
        /// <param name="xDocName">
        /// The XML doc name.
        /// </param>
        /// <returns>
        /// List of cars with their info.
        /// </returns>
        public static List<CarInfoStruct> ParseCarInfo(string xDocName)
        {
            var listOfCars = new List<CarInfoStruct>();
            var car = new CarInfoStruct();
            using (XmlReader reader = XmlReader.Create($@"{xDocName}.xml"))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        switch (reader.Name)
                        {
                            case "mark":
                                car.Mark = reader.ReadString();
                                break;
                            case "model":
                                car.Model = reader.ReadString();
                                break;
                            case "quantity":
                                car.Quantity = Convert.ToInt32(reader.ReadString());
                                break;
                            case "price":
                                car.Price = Convert.ToInt32(reader.ReadString());
                                listOfCars.Add(car);
                                car = default(CarInfoStruct);
                                break;
                        }
                    }
                }
            }

            return listOfCars;
        }
    }
}