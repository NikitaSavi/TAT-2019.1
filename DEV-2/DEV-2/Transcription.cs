using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEV_2
{

    class Transcription
    {
        private readonly StringBuilder word = new StringBuilder();
        private StringBuilder transcription = new StringBuilder();
        private readonly byte syllableCounter; //used for checking the necessity of '+' and for letter 'о'
        List<Letter> letters;

        public Transcription(string receivedArgument)
        {
            char[] vowels = {'а', 'о', 'у', 'ы', 'э', 'я', 'е', 'ё', 'ю', 'и'};
            receivedArgument = receivedArgument.ToLower();
            foreach (var letter in receivedArgument)
            {
                if (!((letter >= 'а' && letter <= 'я') || letter == 'ё' || letter == '+'))
                {
                    throw new Exception("Only russian letters and '+' sign are allowed");
                }

                if (vowels.Contains(letter) || vowels.Contains(letter))
                {
                    //check for the necessity of + being present
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
            letters = new List<Letter> { };
            for (int i = 0; i < word.Length; i++)
            {
                letters.Add(new Letter(word[i]));
            }

            for (int i = 1; i < letters.Count; i++)
            {
                CheckForUnstressedO(i);
                WorkWithIoatedVowels(i);
                CheckVoiceLevel(i);
            }

            foreach (var letter in letters)
            {
                letter.Update();
                transcription.Append(letter.sound);
            }

            return transcription;
        }

        private void CheckForUnstressedO(int i)
        {
            if (word[i] == '+')
            {
                letters[i - 1].VowelStruct.isStressed = true;
            }
        }

        private void WorkWithIoatedVowels(int i)
        {
            if (letters[i].VowelStruct.isIoated)
                if (letters[i - 1].isConsonant)
                {
                    letters[i].VowelStruct.addJSound = false;
                }

            if (letters[i].sound == "и" && letters[i - 1].isConsonant)
            {
                letters[i].VowelStruct.sound = "'и";
            }
        }

        private void CheckVoiceLevel(int i)
        {
            if (letters[i].isConsonant && letters[i].ConsonantStruct.haveVoicePair)
            {
                if ((letters[i].ConsonantStruct.isVoiced &&
                     (i == letters.Count - 1 ||
                      (letters[i + 1].isConsonant && !letters[i + 1].ConsonantStruct.isVoiced))))
                {
                    letters[i].ConsonantStruct.PhonationChanged = true;
                }

                if (i < letters.Count - 1)
                {
                    if (!letters[i - 1].ConsonantStruct.isVoiced && letters[i].ConsonantStruct.isVoiced &&
                        (letters[i + 1].ConsonantStruct.isVoiced || letters[i + 1].isVowel))
                    {
                        letters[i - 1].ConsonantStruct.PhonationChanged = true;
                    }
                }
            }
        }
    }
}
