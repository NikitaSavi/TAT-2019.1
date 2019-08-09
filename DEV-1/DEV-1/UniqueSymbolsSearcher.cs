using System;
using System.Collections.Generic;
using System.Text;

namespace DEV_1
{
    /// <summary>
    /// This class looks for sequences with unique symbols in it
    /// </summary>
    public class UniqueSymbolsSearcher
    {
        /// <summary>
        /// The input line.
        /// </summary>
        private StringBuilder inputLine;

        /// <summary>
        /// Constructor, validates received StringBuilder
        /// </summary>
        /// <param name="receivedArgument">String received as an console argument</param>
        public UniqueSymbolsSearcher(string receivedArgument)
        {
            this.inputLine = new StringBuilder();
            if (receivedArgument.Length < 2)
            {
                throw new FormatException();
            }

            this.inputLine.Append(receivedArgument);
        }

        /// <summary>
        /// Search method to add necessary sequences to a list
        /// </summary>
        /// <returns>List that contains all required sequences</returns>
        public IEnumerable<string> CompileList()
        {
            var sequenceList = new List<string>();
            var sequence = new StringBuilder();

            for (int indexFirst = 0; indexFirst < this.inputLine.Length - 1; indexFirst++)
            {
                sequence.Append(this.inputLine[indexFirst]);
                for (int indexLast = indexFirst + 1; indexLast < this.inputLine.Length; indexLast++)
                {
                    sequence.Append(this.inputLine[indexLast]);
                    if (this.inputLine[indexLast] != this.inputLine[indexLast - 1])
                    {
                        sequenceList.Add(sequence.ToString());
                    }
                    else
                    {
                        break;
                    }
                }

                sequence.Clear();
            }

            return sequenceList;
        }
    }
}