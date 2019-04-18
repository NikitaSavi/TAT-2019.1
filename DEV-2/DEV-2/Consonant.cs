using System;
using System.Linq;

namespace DEV_2
{
    /// <summary>
    /// Struct for consonant letters.
    /// </summary>
    public struct Consonant
    {
        /// <summary>
        /// The sound of the letter.
        /// </summary>
        public string Sound { get; set; }

        /// <summary>
        /// Indicates whether the letter have a voice pair.
        /// </summary>
        public bool HaveVoicePair { get; }

        /// <summary>
        /// Indicates whether the letter is voiced.
        /// </summary>
        public bool IsVoiced { get; }

        /// <summary>
        /// Indicates whether the phonation is changed from default.
        /// </summary>
        public bool PhonationChanged { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Consonant"/> struct. 
        /// </summary>
        /// <param name="letter">
        /// Letter from the received word.
        /// </param>
        public Consonant(char letter)
        {
            if (!Letter.AllConsonants.Contains(letter))
            {
                throw new Exception("Wrong char received.");
            }

            this.Sound = letter.ToString();
            this.HaveVoicePair = Letter.ConsonantPhonationEquivalents.ContainsKey(letter) ||
                            Letter.ConsonantPhonationEquivalents.ContainsValue(letter);
            this.PhonationChanged = false;
            this.IsVoiced = this.HaveVoicePair
                ? Letter.ConsonantPhonationEquivalents.ContainsKey(letter)
                : Letter.AlwaysVoiced.Contains(letter);
        }

        /// <summary>
        /// Updates the sound with necessary changes.
        /// </summary>
        public void Update()
        {
            if (this.PhonationChanged)
            {
                var temp = this.Sound.ToCharArray()[0];
                this.Sound = this.IsVoiced
                    ? Letter.ConsonantPhonationEquivalents[temp].ToString()
                    : Letter.ConsonantPhonationEquivalents.FirstOrDefault(x => x.Value == temp).Key.ToString();
            }
        }
    }
}
