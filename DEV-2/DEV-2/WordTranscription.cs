using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DEV_2
{
    /// <summary>
    /// Main operating class. Handles transcription of words.
    /// </summary>
    public class WordTranscription
    {
        /// <summary>
        /// The entered word.
        /// </summary>
        private string enteredWord;

        /// <summary>
        /// The list of letters.
        /// </summary>
        private List<Letter> listOfLetters;

        /// <summary>
        /// The syllable counter.
        /// </summary>
        private int syllableCounter;

        /// <summary>
        /// The transcription of the entered word.
        /// </summary>
        private StringBuilder transcription;

        /// <summary>
        /// Initializes a new instance of the <see cref="WordTranscription"/> class. 
        /// Validates the entered word.
        /// </summary>
        /// <param name="enteredWord">
        /// The entered word.
        /// </param>
        public WordTranscription(string enteredWord)
        {
            this.EnteredWord = enteredWord;
        }

        /// <summary>
        /// Gets the entered word.
        /// </summary>
        public string EnteredWord
        {
            get => this.enteredWord;
            private set
            {
                if (value.Length == 0)
                {
                    throw new Exception("No word received.");
                }

                if (value[0] == '+')
                {
                    throw new Exception("'+' cannot be at the beginning of the word");
                }

                value = value.ToLower();
                if (!Regex.IsMatch(value, @"^[а-я+ё]+$"))
                {
                    throw new Exception("Only russian letters and '+' sign are allowed.");
                }

                this.syllableCounter = value.Count(x => Letter.AllVowels.Contains(x));
                if (this.syllableCounter > 1)
                {
                    if (!value.Contains('+') && !value.Contains('ё'))
                    {
                        throw new Exception("A '+' sign is needed after a stressed vowel.");
                    }

                    for (var index = 1; index < value.Length; index++)
                    {
                        // Compound words can have multiple stresses
                        if (value[index] == '+')
                        {
                            if (!Letter.AllVowels.Contains(value[index - 1]))
                            {
                                throw new Exception("'+' must be after a stressed vowel");
                            }

                            if (value.Contains('ё') && value[index - 1] != 'ё')
                            {
                                throw new Exception("'ё' is always stressed. '+' is in the wrong place");
                            }
                        }
                    }
                }

                this.enteredWord = value;
            }
        }

        /// <summary>
        /// Gets the transcription.
        /// </summary>
        public StringBuilder Transcription
        {
            get => this.transcription ?? (this.transcription = this.Transcribe());
            private set => this.transcription = value;
        }

        /// <summary>
        /// Transcribes the word.
        /// </summary>
        /// <returns>
        /// Transcription as a string.
        /// </returns>
        public StringBuilder Transcribe()
        {
            this.Transcription = new StringBuilder();
            this.listOfLetters = new List<Letter>();
            foreach (var letter in this.EnteredWord)
            {
                this.listOfLetters.Add(new Letter(letter));
            }

            for (var index = 1; index < this.listOfLetters.Count; index++)
            {
                // Go by each letters, check if changes are necessary
                this.CheckForUnstressedO(index);
                this.WorkWithIoatedVowels(index);

                if (index == 1)
                {
                    this.CheckVoiceLevelDown(index - 1);
                }

                this.CheckVoiceLevelDown(index);
                this.CheckVoiceLevelUp(index);
            }

            foreach (var letter in this.listOfLetters)
            {
                // Updates all changes that were made
                letter.Update();
                this.Transcription.Append(letter.Sound);
            }

            return this.Transcription;
        }

        /// <summary>
        /// The check for unstressed o.
        /// </summary>
        /// <param name="index">
        /// Index of a letter.
        /// </param>
        private void CheckForUnstressedO(int index)
        {
            // If 'о' is unstressed, it's pronounced as 'а'. + sign after a vowel shows the stress
            if (this.EnteredWord[index] == '+' || this.syllableCounter == 1)
            {
                this.listOfLetters[index - 1].vowelStruct.IsStressed = true;
            }
        }

        /// <summary>
        /// Check if ionated letter presence change previous sounds.
        /// </summary>
        /// <param name="index">
        /// Index of a letter.
        /// </param>
        private void WorkWithIoatedVowels(int index)
        {
            // See if adding 'й' sound is necessary
            if (this.listOfLetters[index].vowelStruct.IsIoated && this.listOfLetters[index - 1].IsConsonant)
            {
                this.listOfLetters[index].vowelStruct.AddJSound = false;
            }

            // Additional check for soft consonant before 'и'
            if (this.listOfLetters[index].Sound == "и" && this.listOfLetters[index - 1].IsConsonant)
            {
                this.listOfLetters[index].vowelStruct.Sound = "'и";
            }
        }

        /// <summary>
        /// Check if voice lever needs to change down.
        /// </summary>
        /// <param name="index">
        /// Index of a letter.
        /// </param>
        private void CheckVoiceLevelDown(int index)
        {
            if (this.listOfLetters[index].IsConsonant && this.listOfLetters[index].consonantStruct.HaveVoicePair)
            {
                if (this.listOfLetters[index].consonantStruct.IsVoiced
                    && (index == this.listOfLetters.Count - 1 || (this.listOfLetters[index + 1].IsConsonant
                                                                  && !this.listOfLetters[index + 1].consonantStruct
                                                                      .IsVoiced)))
                {
                    this.listOfLetters[index].consonantStruct.PhonationChanged = true;
                }
            }
        }

        /// <summary>
        /// Check if voice lever needs to change up.
        /// </summary>
        /// <param name="index">
        /// Index of a letter.
        /// </param>
        private void CheckVoiceLevelUp(int index)
        {
            if (this.listOfLetters[index].IsConsonant && this.listOfLetters[index - 1].consonantStruct.HaveVoicePair
                                                      && index < this.listOfLetters.Count - 1)
            {
                if (!this.listOfLetters[index - 1].consonantStruct.IsVoiced
                    && this.listOfLetters[index].consonantStruct.IsVoiced
                    && this.listOfLetters[index + 1].consonantStruct.IsVoiced)
                {
                    this.listOfLetters[index - 1].consonantStruct.PhonationChanged = true;
                }
            }
        }
    }
}