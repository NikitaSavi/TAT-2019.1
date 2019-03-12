using System;

namespace DEV_1
{/// <summary>
/// DEV-1 Task: a program recieves a string (2+ characters) as a console argument, searches for all subsequences in which there are no two consecutive repeated characters
/// </summary>
    class EntryPoint
    {/// <summary>
     /// The entry point to the program
     /// </summary>
     /// <param name="args">Program recieves a string as an console argument</param>
     /// <returns>
     /// Exit codes:
     /// 0 - OK
     /// 1 - issue with the recieved argument
     /// 2 - other errors
     /// </returns>
        static int Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    throw new FormatException();
                }
                foreach (var argument in args)
                {
                    Console.WriteLine("Argument: " + argument);
                    UniqueSymbolsSearcher uniqueSymbolsSearcher = new UniqueSymbolsSearcher(argument);
                    foreach (var sequence in uniqueSymbolsSearcher.CompileList())
                    {
                        Console.WriteLine(sequence);
                    }
                    Console.WriteLine();
                }
                return 0;
            }
            catch (FormatException)
            {
                Console.WriteLine("Error - issue with the recieved argument(s)\nMake sure to send a string with at least 2 characters");
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error - " + ex.Message);
                return 2;
            }
        }
    }
}
