using System;
using System.Collections.Generic;
using System.Text;
//TODO change "string" to "stringBuilder
//TODO consider moving Console.WriteLine in Print(...) to EntryPoint

namespace DEV_1
{/// <summary>
/// This class looks for sequences with unique symbols in it
/// </summary>
    class UniqueSymbolsSearcher
    {
        private string inputLine=string.Empty;
        /// <summary>
        /// Constructor, validates recieved string
        /// </summary>
        /// <param name="recievedArgument">String recieved as an console argument</param>
        public UniqueSymbolsSearcher(string recievedArgument)
        {
            if (recievedArgument.Length < 2) throw new FormatException();
            inputLine = recievedArgument;
        }
        /// <summary>
        /// Search method. Looks for necessary sequences.
        /// </summary>
        /// <returns>sequenceList - list that contains all required sequences</returns>
        public List<string> Search()
        {
            var sequenceList = new List<string>();  //list for sequences
            string sequence = string.Empty;

            for (int indexFirst = 0; indexFirst < inputLine.Length - 1; indexFirst++)
            {//pick each symbol and look for all sequences staring with it 
                sequence += inputLine[indexFirst];

                for (int indexLast = indexFirst + 1; indexLast < inputLine.Length; indexLast++)
                {
                    sequence+=inputLine[indexLast];
                    if (inputLine[indexLast] != inputLine[indexLast - 1])
                    {//add sequences until we either reach the end of the string or encounter two identical symbols
                        sequenceList.Add(sequence);
                    }
                    else break;
                }

                sequence=string.Empty;
            }

            return sequenceList;
        }
        /// <summary>
        /// Print method - prints a recieved list
        /// </summary>
        /// <param name="sequenceList">List of strings to print</param>
        public void Print(List<string> sequenceList)
        {
            foreach (string i in sequenceList)
                Console.WriteLine(i);
        }
    }
}
