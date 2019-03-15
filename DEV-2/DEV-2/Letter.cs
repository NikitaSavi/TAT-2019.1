using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DEV_2
{
    struct Vowel
    {
        public string sound;
        public bool isStressed, isIoated, addJSound;

        public Vowel(char letter)
        {
            isStressed = letter == 'ё';
            isIoated = Letter.vowelIonationEquivalents.ContainsKey(letter);
            addJSound = true;
            sound = isIoated ? Letter.vowelIonationEquivalents[letter].ToString() : letter.ToString();
        }
        public void Update()
        {
            if (sound == "о" && !isStressed)
            {
                sound = "а";
            }
            else if(isIoated)
            {
                sound = addJSound ? ("й" + sound) : ("'" + sound);
            }
        }
    }

    struct Consonant
    {
        public string sound;
        public bool haveVoicePair, isVoiced, PhonationChanged;
        public Consonant(char letter)
        {
            sound=letter.ToString();
            haveVoicePair = Letter.consonantPhonationEquivalents.ContainsKey(letter) ||
                            Letter.consonantPhonationEquivalents.ContainsValue(letter);
            PhonationChanged = false;
            isVoiced = haveVoicePair
                ? Letter.consonantPhonationEquivalents.ContainsKey(letter)
                : Letter.alwaysVoiced.Contains(letter);


        }

        public void Update()
        {
            if (PhonationChanged)
            {
                char temp = sound.ToCharArray()[0];
                sound = isVoiced
                    ? Letter.consonantPhonationEquivalents[temp].ToString()
                    : Letter.consonantPhonationEquivalents.FirstOrDefault(x => x.Value == temp).Key.ToString();
            }
        }
    }

    struct Special
    {
        public string sound;
        public Special(char letter)
        {
            sound = letter == 'ь' ? "'" : string.Empty;
        }
    }

    class Letter
    {
        public string sound;
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
