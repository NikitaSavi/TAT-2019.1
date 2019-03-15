using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEV_2
{/// <summary>
/// Class that transcribes the received word
/// </summary>
    class Transcription
    {
        private readonly StringBuilder word = new StringBuilder();
        private StringBuilder transcription = new StringBuilder();
        private readonly char[] vowels = { 'а', 'о', 'у', 'ы', 'э', 'я', 'е', 'ё', 'ю', 'и' };
        private readonly char[] consonants = { 'б', 'в', 'г', 'д', 'й', 'ж', 'з', 'к', 'л', 'м', 'н', 'п', 'р', 'с', 'т', 'ф', 'х', 'ц', 'ч', 'ш', 'щ' };
        private readonly byte syllableCounter; //used for checking the necessity of '+' and for letter 'о'

        private readonly Dictionary<char, char> vowelIonationEquivalents = new Dictionary<char, char>
        {
            ['е'] = 'э',
            ['ё'] = 'о',
            ['ю'] = 'у',
            ['я'] = 'а'
        };
        private readonly Dictionary<char, char> consonantPhonationEquivalents = new Dictionary<char, char>
        {
            ['б'] = 'п',
            ['в'] = 'ф',
            ['г'] = 'к',
            ['д'] = 'т',
            ['ж'] = 'ш',
            ['з'] = 'с'
        };
        /// <summary>
        /// Constructor, validates received StringBuilder
        /// </summary>
        /// <param name="receivedArgument">String received as an console argument</param>
        public Transcription(string receivedArgument)
        {
            receivedArgument = receivedArgument.ToLower();
            foreach (char letter in receivedArgument)
            {
                if (!((letter >= 'а' && letter <= 'я') || letter == 'ё' || letter == '+'))
                {
                    throw new Exception("Only russian letters and '+' sign are allowed");
                }
                //check for the necessity of + being present
                if (vowels.Contains(letter) || vowels.Contains(letter))
                {
                    syllableCounter++;
                }
            }
            if (syllableCounter > 1 && !receivedArgument.Contains('+') && !receivedArgument.Contains('ё'))
            {
                throw new Exception("A '+' sign is needed after a stressed vowel");
            }
            word.Append(receivedArgument);
        }

        public StringBuilder Transcribe()
        {
            for (var index = 0; index < word.Length; index++)
            {
                switch (GetLetterType(index))
                {
                    case 0:
                        if (vowelIonationEquivalents.ContainsKey(word[index]))
                        {
                            transcription.Append(CheckVowelIonation(index));
                        }
                        else if (word[index] == 'о')
                        {
                            transcription.Append(Check_O_ForStress(index));
                        }
                        else
                        {
                            transcription.Append(word[index]);
                        }

                        break;
                    case 1:
                        if (consonantPhonationEquivalents.ContainsKey(word[index]) || consonantPhonationEquivalents.ContainsValue(word[index]))
                        {
                            transcription.Append(CheckConsonantPhonation(index));
                        }
                        else
                        {
                            transcription.Append(word[index]);
                        }

                        break;
                    case 2:
                        if (word[index] == 'ь')
                        {
                            transcription.Append('\''); 
                        }

                        break;
                }
            }
            return transcription;
        }
        /// <summary>
        /// Returns corresponding index for the type of the letter
        /// </summary>
        /// <param name="index"></param>
        /// <returns>0 - vowel, 1 - consonant, 3 - other symbols</returns>
        private int GetLetterType(int index)
        {
            return vowels.Contains(word[index]) ? 0 : (consonants.Contains(word[index]) ? 1 : 2);
        }

        private char Check_O_ForStress(int index)
        {
            if (syllableCounter > 1 && word[index] == 'о' && (index == word.Length - 1 || word[index + 1] != '+'))
            {
                return 'а';
            }
            return 'о';
        }

        private char CheckVowelIonation(int index)
        {
            if (index != 0 && consonants.Contains(word[index - 1]))
            {
                transcription.Append("\'");
            }
            else
            {
                transcription.Append("й");
            }
            return vowelIonationEquivalents[word[index]];
        }

        private char CheckConsonantPhonation(int index)
        {
            switch (consonantPhonationEquivalents.ContainsKey(word[index]))
            {
                case true:
                    if ((index == word.Length - 1) ||
                        (index != 0) &&
                        (consonantPhonationEquivalents.ContainsValue(word[index - 1]) ||
                         vowels.Contains(word[index - 1]) || word[index - 1] == '+'))
                    {
                        return consonantPhonationEquivalents[word[index]];
                    }

                    break;
                case false:
                    if (index != word.Length - 1 && consonantPhonationEquivalents.ContainsKey(word[index + 1]))
                    {
                        return consonantPhonationEquivalents.First(x => x.Value == word[index]).Key;
                    }
                    break;
            }
            return word[index];
        }
    }
}