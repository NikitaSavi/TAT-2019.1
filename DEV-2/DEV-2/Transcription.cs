using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEV_2
{/// <summary>
/// Main operating class. Handles transcription of words
/// </summary>
    class Transcription
    {
        private readonly StringBuilder enteredWord = new StringBuilder();
        private readonly StringBuilder transcription = new StringBuilder(); //stores final transcription as a string
        private List<Letter> listOfLetters; //stores all letter features

        public Transcription(string enteredWord)
        {
            this.enteredWord.Append(enteredWord);
        }
        /// <summary>
        /// Core method of the class
        /// </summary>
        /// <returns>Returns transcription as a string</returns>
        public StringBuilder Transcribe()
        {
            listOfLetters = new List<Letter> { };
            for (int i = 0; i < enteredWord.Length; i++)
            {
                listOfLetters.Add(new Letter(enteredWord[i]));
            }

            for (int i = 1; i < listOfLetters.Count; i++)
            {//going by each letters, checking if changes are necessary
                CheckForUnstressedO(i);
                WorkWithIoatedVowels(i);
                CheckVoiceLevel(i);
            }

            foreach (var letter in listOfLetters)
            {
                letter.Update(); //updates all changes that were made
                transcription.Append(letter.sound);
            }

            return transcription;
        }

        private void CheckForUnstressedO(int i)
        {//if 'о' is unstressed, it's pronounced as 'а'. + sign after a vowel shows the stress
            if (enteredWord[i] == '+')
            {
                listOfLetters[i - 1].VowelStruct.isStressed = true;
            }
        }

        private void WorkWithIoatedVowels(int i)
        {//see if adding 'й' sound is necessary
            if (listOfLetters[i].VowelStruct.isIoated)
                if (listOfLetters[i - 1].isConsonant)
                {
                    listOfLetters[i].VowelStruct.addJSound = false;
                }
            //additional check for soft consonant before 'и' TODO add soft/hard as a cons.feature maybe?
            if (listOfLetters[i].sound == "и" && listOfLetters[i - 1].isConsonant)
            {
                listOfLetters[i].VowelStruct.sound = "'и";
            }
        }

        private void CheckVoiceLevel(int i)
        {
            if (listOfLetters[i].isConsonant && listOfLetters[i].ConsonantStruct.haveVoicePair)
            {//voiced sounds become unvoiced after unvoiced sounds or at the word's end
                if ((listOfLetters[i].ConsonantStruct.isVoiced &&
                     (i == listOfLetters.Count - 1 ||
                      (listOfLetters[i + 1].isConsonant && !listOfLetters[i + 1].ConsonantStruct.isVoiced))))
                {
                    listOfLetters[i].ConsonantStruct.PhonationChanged = true;
                }

                if (i < listOfLetters.Count - 1)
                {//unvoiced sounds become voiced before double voiced sounds
                    if (!listOfLetters[i - 1].ConsonantStruct.isVoiced && listOfLetters[i].ConsonantStruct.isVoiced &&
                        (listOfLetters[i + 1].ConsonantStruct.isVoiced || listOfLetters[i + 1].isVowel))
                    {
                        listOfLetters[i - 1].ConsonantStruct.PhonationChanged = true;
                    }
                }
            }
        }
    }
}
