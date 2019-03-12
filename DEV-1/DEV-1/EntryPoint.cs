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
     /// 2 - unknown error
     /// </returns>
        static int Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    throw new FormatException();
                }
                UniqueSymbolsSearcher uniqueSymbolsSearcher = new UniqueSymbolsSearcher(args[0]);
                uniqueSymbolsSearcher.Print(uniqueSymbolsSearcher.Search());
                return 0;
            }
            catch (FormatException)
            {
                Console.WriteLine("Error - issue with the recieved argument\nMake sure to send a string with 2 characters at least");
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unknown error");
                Console.WriteLine(ex.Message);
                return 2;
            }
        }
    }
}
