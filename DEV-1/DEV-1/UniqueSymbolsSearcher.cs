using System;
using System.Collections.Generic;
using System.Text;
//TODO change "string" to "stringBuilder
namespace DEV_1
{
    class UniqueSymbolsSearcher
    {
        private string inputLine=string.Empty;

        public UniqueSymbolsSearcher(string recievedArgument)
        {
            if (recievedArgument.Length < 2) throw new FormatException();
            inputLine = recievedArgument;

        }
        


        public List<string> Search()
        {
            var sequenceList = new List<string>();     
            string sequence=string.Empty;
            for (int i = 0; i < inputLine.Length - 1; i++)
            {
                sequence+=inputLine[i];

                for (int j = i + 1; j < inputLine.Length; j++)
                {
                    sequence+=inputLine[j];
                    if (inputLine[j] != inputLine[j - 1])
                    {
                        sequenceList.Add(sequence);
                    }
                    else break;
                }

                sequence=null;
            }
            return sequenceList;
        }
        public void Print(List<string> sequenceList)
        {
            foreach (var i in sequenceList)
                Console.WriteLine(i);
        }
    }
}
