using System;
using System.Linq;

namespace DEV_2
{
    /// <summary>
    /// Struct for vowel letters.
    /// </summary>
    public struct Vowel
    {
        /// <summary>
        /// The sound of the letter.
        /// </summary>
        public string Sound { get; set; }

        /// <summary>
        /// Indicates whether the letter is stressed.
        /// </summary>
        public bool IsStressed { get; set; }

        /// <summary>
        /// Indicates whether the letter is ioated.
        /// </summary>
        public bool IsIoated { get; }

        /// <summary>
        /// Indicates whether to add j sound.
        /// </summary>
        public bool AddJSound { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vowel"/> struct. 
        /// </summary>
        /// <param name="letter">
        /// Letter from the received word.
        /// </param>
        public Vowel(char letter)
        {
            if (!Letter.AllVowels.Contains(letter))
            {
                throw new Exception("Wrong char received.");
            }

            this.IsStressed = letter == 'ё';
            this.IsIoated = Letter.VowelIonationEquivalents.ContainsKey(letter);
            this.AddJSound = true;
            this.Sound = this.IsIoated ? Letter.VowelIonationEquivalents[letter].ToString() : letter.ToString();
        }

        /// <summary>
        /// Updates the sound with necessary changes.
        /// </summary>
        public void Update()
        {
            if (this.Sound == "о" && !this.IsStressed)
            {
                this.Sound = "а";
            }
            else if (this.IsIoated)
            {
                this.Sound = this.AddJSound ? "й'" + this.Sound : "'" + this.Sound;
            }
        }
    }
}
