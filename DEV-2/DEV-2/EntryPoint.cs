using System;

namespace DEV_2
{/// <summary>
/// DEV-2 Task: Transcription of the receives console argument
/// </summary>
    class EntryPoint
    {/// <summary>
     /// The entry point to the program
     /// </summary>
     /// <param name="args">Program receives a string as an console argument
     /// String must contain a '+' sign to show the stressed vowel, unless there is only one syllable, or 'ё' is present</param>
     /// <returns>
     /// Exit codes:
     /// 0 - OK
     /// 1 - errors
     /// </returns>
        static int Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    throw new Exception("No arguments received");
                }
                foreach (var argument in args)
                {
                    var transcription = new Transcription(argument);
                    Console.WriteLine(argument.ToLower() + " -> " + transcription.Transcribe());
                }
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error - " + ex.Message);
                return 1;
            }
        }
    }
}
