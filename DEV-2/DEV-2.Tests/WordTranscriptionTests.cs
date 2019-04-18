using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DEV_2.Tests
{
    /// <summary>
    /// Tests for <see cref="WordTranscription"/> class.
    /// </summary>
    [TestClass]
    public class WordTranscriptionTests
    {
        /// <summary>
        /// Negative test for setting EnteredWord in the class. 
        /// Entering empty string must result in exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception), "No word received.")]
        public void EnteredWordSet_EmptyInput_ThrowException()
        {
            var transctiber = new WordTranscription(string.Empty);
        }

        /// <summary>
        /// Negative test for setting EnteredWord in the class. 
        /// Word must contain either '+', 'ё' or just one syllable.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception), "A '+' sign is needed after a stressed vowel.")]
        public void EnteredWordSet_NoStressSign_ThrowException()
        {
            var transctiber = new WordTranscription("слово");
        }

        /// <summary>
        /// Negative test for setting EnteredWord in the class. 
        /// '+' cannot be at the beginning of the word.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception), "'+' cannot be at the beginning of the word")]
        public void EnteredWordSet_StressSignFirstChar_ThrowException()
        {
            var transctiber = new WordTranscription("+слово");
        }

        /// <summary>
        /// Negative test for setting EnteredWord in the class. 
        /// '+' cannot be after consonants.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception), "'+' must be after a stressed vowel")]
        public void EnteredWordSet_StressAfterConsonant_ThrowException()
        {
            var transctiber = new WordTranscription("сл+ово");
        }

        /// <summary>
        /// Positive test for setting EnteredWord in the class. 
        /// '+' is unnecessary if: only one syllable, 'ё' is present.
        /// </summary>
        /// <param name="input">
        /// Entered word.
        /// </param>
        /// <param name="expected">
        /// Expected result.
        /// </param>
        [DataTestMethod]
        [DataRow("овёс", "ав'ос")]
        [DataRow("нон", "нон")]
        public void EnteredWordSet_NoPlusNeeded_NoException(string input, string expected)
        {
            var transctiber = new WordTranscription(input);
        }

        /// <summary>
        /// Negative test for setting EnteredWord in the class. 
        /// Word must contain only russian letters and '+'.
        /// </summary>
        /// <param name="input">
        /// Entered word.
        /// </param>
        [DataTestMethod]
        [DataRow("abc_3$%.)")]
        [DataRow("сло+вtо")]
        [ExpectedException(typeof(Exception), "Only russian letters and '+' sign are allowed.")]
        public void EnteredWordSet_IncorrectCharacters_ThrowException(string input)
        {
            var transctiber = new WordTranscription(input);
        }

        /// <summary>
        /// Positive test for CheckForUnstressedO method.
        /// Req 1.: Unstressed 'о' is read as 'а'.
        /// </summary>
        /// <param name="input">
        /// Entered word.
        /// </param>
        /// <param name="expected">
        /// Expected result.
        /// </param>
        [DataTestMethod]
        [DataRow("сло+во", "слова")]
        [DataRow("словё", "слав'о")]
        [DataRow("нон", "нон")]
        public void CheckForUnstressedO_WordsWithOLetter_OisAWhereNecessary(string input, string expected)
        {
            var transcriber = new WordTranscription(input);
            var actual = transcriber.Transcribe();
            Assert.AreEqual(expected, actual.ToString());
        }

        /// <summary>
        /// Positive test for WorkWithIoatedVowels method.
        /// Req 2.: "Soft" vowels sounds after consonants change to their pairs and soften previous sound.
        /// Additional check that not-"soft" vowels don't do such things.
        /// </summary>
        [TestMethod]
        public void WorkWithIoatedVowels_IoatedAfterConsonants_PairChanged()
        {
            var transcriber = new WordTranscription("бибябебёбю");
            var actual = transcriber.Transcribe();
            Assert.AreEqual("б'иб'аб'эб'об'у", actual.ToString());
        }

        /// <summary>
        /// Positive test for WorkWithIoatedVowels method.
        /// Additional check for req.2 that not-"soft" vowels don't change.
        /// </summary>
        [TestMethod]
        public void WorkWithIoatedVowels_NonIoatedVowelsAfterConsonants_NothingChanges()
        {
            var transcriber = new WordTranscription("быбабэбо+бу");
            var actual = transcriber.Transcribe();
            Assert.AreEqual("быбабэбобу", actual.ToString());
        }

        /// <summary>
        /// Positive test for WorkWithIoatedVowels method.
        /// Req 3.: Ioated vowel sounds after vowels, specials, in the beginning of the word change to their pairs and put 'й' before them.
        /// </summary>
        /// <param name="input">
        /// Entered word.
        /// </param>
        /// <param name="expected">
        /// Expected result.
        /// </param>
        [DataTestMethod]
        [DataRow("янаюъемьё", "й'анай'уй'эм'й'о")]
        [DataRow("сло+ю", "слой'у")] // After + sign 
        public void WorkWithIoatedVowels_IoatedWhereJIsNeeded_JAddedPairChanged(string input, string expected)
        {
            var transcriber = new WordTranscription(input);
            var actual = transcriber.Transcribe();
            Assert.AreEqual(expected, actual.ToString());
        }

        /// <summary>
        /// Positive test for CheckVoiceLevelUp method.
        /// Req 4.: Consonants change their voice level: voiceless to voiced - before double voiced consonant sounds.
        /// </summary>
        [TestMethod]
        public void CheckVoiceLevelUp_Consonants_VoiceLevelChanges()
        {
            var transcriber = new WordTranscription("кнн");
            var actual = transcriber.Transcribe();
            Assert.AreEqual("гнн", actual.ToString());
        }

        /// <summary>
        /// Positive test for CheckVoiceLevelUp method.
        /// Req 4.: Consonants change their voice level: voiced to voiceless - at the word's end and before voiceless consonant sound.
        /// </summary>
        [TestMethod]
        public void CheckVoiceLevelDown_Consonants_VoiceLevelChanges()
        {
            var transcriber = new WordTranscription("зпг");
            var actual = transcriber.Transcribe();
            Assert.AreEqual("спк", actual.ToString());
        }
    }
}
