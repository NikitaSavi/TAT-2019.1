using System;
using System.Linq;

namespace DEV_2
{
    /// <summary>
    /// The struct for special letters.
    /// </summary>
    public struct SpecialLetter
    {
        /// <summary>
        /// The "sound" of the letter.
        /// </summary>
        public string Sound { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpecialLetter"/> struct. 
        /// </summary>
        /// <param name="letter">
        /// Letter from the received word
        /// </param>
        public SpecialLetter(char letter)
        {
            if (!Letter.AllSpecials.Contains(letter))
            {
                throw new Exception("Wrong char received.");
            }

            this.Sound = letter == 'ь' ? "'" : string.Empty;
        }
    }
}
