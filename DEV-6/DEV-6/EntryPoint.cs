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
        /// Name of the XML documents to parse.
        /// </param>
        /// <returns>Operation codes: 0 - OK, 1 - Error.</returns>
        private static int Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    throw new ArgumentNullException();
                }

                CommandsInvoker.InvokeCommands(args[0], args[1]);

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