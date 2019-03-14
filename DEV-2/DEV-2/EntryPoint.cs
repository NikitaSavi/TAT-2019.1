using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_2
{/// <summary>
/// DEV-2 Task: Transcription of the recieved console argument
/// </summary>
    class EntryPoint
    {/// <summary>
     /// The entry point to the program
     /// </summary>
     /// <param name="args">Program recieves a string as an console argument
     /// String must contain a '+' sign to show the stressed vovel, unless there is only one syllable, or 'ё' is present</param>
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
                    throw new ArgumentException();
                }
                foreach (var argument in args)
                {
                    Transcription transcription = new Transcription(argument);
                    Console.WriteLine(argument + " -> " + transcription.Transcribe());
                }
                return 0;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Error - No arguments recieved");
                return 1;
            }
            catch (FormatException)
            {
                Console.WriteLine("TODO write smth here");
                return 1;
            }
            catch (Exception error)
            {
                Console.WriteLine("Error - " + error.Message);
                return 2;
            }
        }
    }
}
