using System;
using CW_9.DriverFactory;
using CW_9.WriterFactory;

namespace CW_9
{
    /// <summary>
    /// Get JSON/XML file with currencies exchange rates.
    /// </summary>
    public class EntryPoint
    {
        /// <summary>
        /// The entry point.
        /// </summary>
        /// <returns>
        /// 0: OK; 1: Error.
        /// </returns>
        private static int Main()
        {
            try
            {
                Console.WriteLine("filename.extension browser");
                string[] args;
                do
                {
                    args = Console.ReadLine()?.ToLower().Split(' ');
                }
                while (args.Length != 2);
                
                var driver = new DriverSelector().GetDriver(args[1]).Create();
                var myfinPage = new MyfinPage(driver);
                var currencies = myfinPage.GetCurrencies();
                new WriterSelector().GetWriter(args[0]).Write(currencies);

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