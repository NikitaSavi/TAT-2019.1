using System;

namespace DEV_1
{/// <summary>
/// DEV-1 Task: a program recieves a string (2+ characters) as a console argument, searches for all subsequences in which there are no two consecutive repeated characters
/// </summary>
    class EntryPoint
    {/// <summary>
     /// The entry point to the program
     /// </summary>
     /// <param name="args"></param>
     /// <returns>
     /// Exit codes:
     /// 0 - OK
     /// 1 - no arguments recieved
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
                string line = string.Empty;
                foreach (string i in args)
                {
                    line += i + " ";
                }
                line = line.TrimEnd();
                Console.WriteLine("Your line is: " + line);
                Subseq_search subseq_search = new Subseq_search();
                subseq_search.Search(line);
                return 0;
            }
            catch (FormatException)
            {
                Console.WriteLine("Error - no arguments recieved");
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unknown error, exit code: " + ex.Message);
                return 2;
            }
        }
    }
}
