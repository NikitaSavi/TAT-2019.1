using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_2
{/// <summary>
/// Class that transcribes the recieved word
/// </summary>
    class Transcription
    {
        private StringBuilder word = new StringBuilder();
        private readonly string[] typeOfLetter = { "аоэуыи", "яёею", "бвгджзйклмнпрстфхцчшщ", "ьъ+" };
        /*vowels: 0 - nonioated, 1 - ioated;
        2 - consonants; (TODO additional types for cons. might be necessary)
        3 - special letters*/
        /// <summary>
        /// Constructor, validates recieved StringBuilder
        /// </summary>
        /// <param name="recievedArgument">String recieved as an console argument</param>
        public Transcription(string recievedArgument)
        {
            foreach (char letter in recievedArgument)
            {
                if (!((letter >= 'А' && letter <= 'я') || letter == 'ё' || letter == 'Ё' || letter == '+'))
                {//TODO checks for +
                    throw new FormatException();
                }
            }
            word.Append(recievedArgument);
        }

        public StringBuilder Transcribe()
        {
            StringBuilder transcription = new StringBuilder();
            for (int index = 0; index < word.Length; index++)
            {
                switch (GetLetterType(index))
                {
                    case 0: //hard vowel
                        if (word[index] == 'о' && (index == word.Length - 1 || word[index + 1] != '+'))
                        {//1. The unstressed 'о' reads as 'а'
                            transcription.Append('а');
                            break;
                        }
                        if (word[index] == 'и' && index != 0) 
                        {//2. Soft vowels soften the previous consonant sound
                            transcription.Append('\'');
                        }
                        transcription.Append(word[index]);
                        break;
                    case 1: //soft vowel
                        if (index == 0 || GetLetterType(index - 1) <= 1 || GetLetterType(index - 1) == 3)
                        {//3. Ioated vowels at the beginning of a word, after other vowels or after "ь", "ъ" are converted into 'й'+'their hard vowel equivalent'
                            transcription.Append('й');         
                        }
                        else
                        {//2. Ioated vowels soften the previous consonant sound and are converted to their hard vowel equivalent
                            transcription.Append('\'');
                        }
                        transcription.Append(typeOfLetter[0][typeOfLetter[1].IndexOf(word[index])]);
                        break;
                    case 2: //consonant 
                        transcription.Append(word[index]);
                        break;
                    case 3: //special
                        break;
                }
            }
            return transcription;
        }

        public int GetLetterType(int index)
        {
            for (int i = 0; i < typeOfLetter.Length; i++)
            {
                if (typeOfLetter[i].Contains(word[index]))
                {
                    return i;
                }
            }
            return 3;//TODO this is here to fix "not all code paths return a value" error, need a better fix
        }
    }
}
