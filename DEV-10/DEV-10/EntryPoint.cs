using System;

namespace DEV_10
{
    /// <summary>
    /// DEV-10: Shop, operates with JSON database, writes to XML.
    /// </summary>
    public class EntryPoint
    {
        /// <summary>
        /// The entry point to the program.
        /// </summary>
        /// <returns>
        /// Error codes: 0 - OK, 1 - error.
        /// </returns>
        private static int Main()
        {
            try
            {
                var shop = new Shop();
                shop.ReadDatabase();
                foreach (var item in shop.ProductsList)
                {
                    item.ShowInfoToConsole();
                }

                shop.WriteToXml();
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 1;
            }
        }
    }
}
