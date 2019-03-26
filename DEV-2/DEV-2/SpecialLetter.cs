namespace DEV_2
{
    struct Special
    {
        public string sound;

        /// <summary>
        /// Fills the fields with default characteristics 
        /// </summary>
        /// <param name="letter">Letter from the received word</param>
        public Special(char letter)
        {
            sound = letter == 'ь' ? "'" : string.Empty;
        }
    }
}
