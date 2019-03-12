using System;
using System.Collections.Generic;
using System.Text;

namespace DEV_1
{/// <summary>
/// This class looks for sequences with unique symbols in it
/// </summary>
    class UniqueSymbolsSearcher
    {
        private StringBuilder inputLine = new StringBuilder();
        /// <summary>
        /// Constructor, validates recieved StringBuilder
        /// </summary>
        /// <param name="recievedArgument">String recieved as an console argument</param>
        public UniqueSymbolsSearcher(string recievedArgument)
        {
            if (recievedArgument.Length < 2)
            {
                throw new FormatException();
            }
            inputLine.Append(recievedArgument);
        }
        /// <summary>
        /// Search method to add necessary sequences to a list
        /// </summary>
        /// <returns>List that contains all required sequences</returns>
        public List<string> CompileList()
        {
            List<string> sequenceList = new List<string>();  //list for sequences
            StringBuilder sequence = new StringBuilder();

            for (int indexFirst = 0; indexFirst < inputLine.Length - 1; indexFirst++)
            {//pick each symbol and look for all sequences staring with it 
                sequence.Append(inputLine[indexFirst]);

                for (int indexLast = indexFirst + 1; indexLast < inputLine.Length; indexLast++)
                {
                    sequence.Append(inputLine[indexLast]);
                    if (inputLine[indexLast] != inputLine[indexLast - 1])
                    {//add sequences until we either reach the end of the string or encounter two identical symbols
                        sequenceList.Add(sequence.ToString());
                    }
                    else break;
                }

                sequence.Clear();
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
            {
                Console.WriteLine(i);
            }
        }
    }
}
