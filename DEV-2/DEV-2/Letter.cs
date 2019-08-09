using System;
using System.Collections.Generic;
using System.Linq;

namespace DEV_2
{
    /// <summary>
    /// Additional class for storing the features of the letters.
    /// </summary>
    public class Letter
    {
        /// <summary>
        /// For quick access when displaying transcription.
        /// </summary>
        public string Sound { get; set; }

        /// <summary>
        /// The vowel struct.
        /// </summary>
        public Vowel vowelStruct;

        /// <summary>
        /// The consonant struct.
        /// </summary>
        public Consonant consonantStruct;

        /// <summary>
        /// The special letters struct.
        /// </summary>
        public SpecialLetter specialStruct;

        /// <summary>
        /// Indicates whether the letter is a vowel.
        /// </summary>
        public bool IsVowel { get; }

        /// <summary>
        /// Indicates whether the letter is a consonant.
        /// </summary>
        public bool IsConsonant { get; }

        /// <summary>
        /// The vowels.
        /// </summary>
        public static readonly char[] AllVowels =
            {
                'а', 'о', 'у', 'ы', 'э', 'я', 'е', 'ё', 'ю', 'и'
            };

        /// <summary>
        /// The consonants.
        /// </summary>
        public static readonly char[] AllConsonants =
            {
                'б', 'в', 'г', 'д', 'й', 'ж', 'з', 'к', 'л', 'м', 'н', 'п', 'р', 'с', 'т', 'ф', 'х', 'ц', 'ч', 'ш', 'щ'
            };

        /// <summary>
        /// The special letters.
        /// </summary>
        public static readonly char[] AllSpecials =
            {
                'ь', 'ъ', '+'
            };

        /// <summary>
        /// The always voiced consonants.
        /// </summary>
        public static readonly char[] AlwaysVoiced =
            {
                'й', 'л', 'м', 'н', 'р'
            };

        /// <summary>
        /// The vowel ionation equivalents.
        /// </summary>
        public static readonly Dictionary<char, char> VowelIonationEquivalents = new Dictionary<char, char>
        {
            ['е'] = 'э',
            ['ё'] = 'о',
            ['ю'] = 'у',
            ['я'] = 'а'
        };

        /// <summary>
        /// The consonant phonation equivalents.
        /// </summary>
        public static readonly Dictionary<char, char> ConsonantPhonationEquivalents = new Dictionary<char, char>
        {
            ['б'] = 'п',
            ['в'] = 'ф',
            ['г'] = 'к',
            ['д'] = 'т',
            ['ж'] = 'ш',
            ['з'] = 'с'
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="Letter"/> class. 
        /// Checks the type of the letter.
        /// </summary>
        /// <param name="letter">
        /// Letter from the received word.
        /// </param>
        public Letter(char letter)
        {
            if (AllVowels.Contains(letter))
            {
                this.vowelStruct = new Vowel(letter);
                this.IsVowel = true;
                this.Sound = this.vowelStruct.Sound;
            }
            else if (AllConsonants.Contains(letter))
            {
                this.consonantStruct = new Consonant(letter);
                this.IsConsonant = true;
                this.Sound = this.consonantStruct.Sound;
            }
            else if (AllSpecials.Contains(letter))
            {
                this.specialStruct = new SpecialLetter(letter);
                this.Sound = this.specialStruct.Sound;
            }
            else
            {
                throw new Exception("Unknown char received.");
            }
        }

        /// <summary>
        /// Calls appropriate update functions.
        /// </summary>
        public void Update()
        {
            if (this.IsVowel)
            {
                this.vowelStruct.Update();
                this.Sound = this.vowelStruct.Sound;
            }
            else if (this.IsConsonant)
            {
                this.consonantStruct.Update();
                this.Sound = this.consonantStruct.Sound;
            }
        }
    }
}