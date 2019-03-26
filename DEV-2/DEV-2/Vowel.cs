namespace DEV_2
{
    struct Vowel
    {
        public string sound;
        public bool isStressed, isIoated, addJSound;

        /// <summary>
        /// Fills the fields with default characteristics 
        /// </summary>
        /// <param name="letter">Letter from the received word</param>
        public Vowel(char letter)
        {
            isStressed = letter == 'ё';
            isIoated = Letter.vowelIonationEquivalents.ContainsKey(letter);
            addJSound = true;
            sound = isIoated ? Letter.vowelIonationEquivalents[letter].ToString() : letter.ToString();
        }

        public void Update()
        {
            //updates with necessary changes
            if (sound == "о" && !isStressed)
            {
                sound = "а";
            }
            else if (isIoated)
            {
                sound = addJSound ? ("й" + sound) : ("'" + sound);
            }
        }
    }
}
