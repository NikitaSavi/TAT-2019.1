using System;

namespace DEV_6
{
    /// <summary>
    /// DEV-6: get information about cars by parsing XML document.
    /// </summary>
    public class EntryPoint
    {
        /// <summary>
        /// The entry point.
        /// </summary>
        /// <param name="args">
        /// Names of the XML documents to parse.
        /// </param>
        /// <returns>
        /// Operation codes: 0 - OK, 1 - Error.
        /// </returns>
        private static int Main(string[] args)
        {
            try
            {
                if (args.Length < 2)
                {
                    throw new ArgumentOutOfRangeException();
                }

                CommandsInvoker.InvokeCommands(args[0], args[1]);

                return 0;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine(
                    "2 arguments are required: XML doc name with cars info and XML doc name with trucks info");
                return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 1;
            }
        }
    }
}