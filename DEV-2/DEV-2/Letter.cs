using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DEV_2
{
    /// <summary>
    /// Additional class for storing the features of the letters
    /// </summary>
    class Letter
    {
        public string sound; //for quick access when displaying transcription
        public Vowel VowelStruct;
        public Consonant ConsonantStruct;
        public Special SpecialStruct;

        public readonly bool isVowel;
        public readonly bool isConsonant;
        private static readonly char[] vowels = {'а', 'о', 'у', 'ы', 'э', 'я', 'е', 'ё', 'ю', 'и'};

        private static readonly char[] consonants =
            {'б', 'в', 'г', 'д', 'й', 'ж', 'з', 'к', 'л', 'м', 'н', 'п', 'р', 'с', 'т', 'ф', 'х', 'ц', 'ч', 'ш', 'щ'};

        public static readonly char[] alwaysVoiced = {'й', 'л', 'м', 'н', 'р'};
        static char[] special = {'ь', 'ъ', '+'};

        internal static readonly Dictionary<char, char> vowelIonationEquivalents = new Dictionary<char, char>
        {
            ['е'] = 'э',
            ['ё'] = 'о',
            ['ю'] = 'у',
            ['я'] = 'а'
        };

        internal static readonly Dictionary<char, char> consonantPhonationEquivalents = new Dictionary<char, char>
        {
            ['б'] = 'п',
            ['в'] = 'ф',
            ['г'] = 'к',
            ['д'] = 'т',
            ['ж'] = 'ш',
            ['з'] = 'с'
        };

        /// <summary>
        /// Constructor: checks the type of the letter
        /// </summary>
        /// <param name="letter">Letter from the received word</param>
        public Letter(char letter)
        {
            if (vowels.Contains(letter))
            {
                VowelStruct = new Vowel(letter);
                isVowel = true;
                sound = VowelStruct.sound;
            }
            else if (consonants.Contains(letter))
            {
                ConsonantStruct = new Consonant(letter);
                isConsonant = true;
                sound = ConsonantStruct.sound;
            }
            else
            {
                SpecialStruct = new Special(letter);
                sound = SpecialStruct.sound;
            }
        }

        public void Update()
        {
            //calls appropriate update functions
            if (isVowel)
            {
                VowelStruct.Update();
                sound = VowelStruct.sound;
            }
            else if (isConsonant)
            {
                ConsonantStruct.Update();
                sound = ConsonantStruct.sound;
            }
        }
    }
}