using System.Linq;

namespace DEV_2
{

    struct Consonant
    {
        public string sound;
        public bool haveVoicePair, isVoiced, PhonationChanged;

        /// <summary>
        /// Fills the fields with default characteristics 
        /// </summary>
        /// <param name="letter">Letter from the received word</param>
        public Consonant(char letter)
        {
            sound = letter.ToString();
            haveVoicePair = Letter.consonantPhonationEquivalents.ContainsKey(letter) ||
                            Letter.consonantPhonationEquivalents.ContainsValue(letter);
            PhonationChanged = false;
            isVoiced = haveVoicePair
                ? Letter.consonantPhonationEquivalents.ContainsKey(letter)
                : Letter.alwaysVoiced.Contains(letter);


        }

        public void Update()
        {
            //updates with necessary changes
            if (PhonationChanged)
            {
                char temp = sound.ToCharArray()[0];
                sound = isVoiced
                    ? Letter.consonantPhonationEquivalents[temp].ToString()
                    : Letter.consonantPhonationEquivalents.FirstOrDefault(x => x.Value == temp).Key.ToString();
            }
        }
    }
}
