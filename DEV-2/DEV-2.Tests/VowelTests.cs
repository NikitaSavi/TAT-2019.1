using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DEV_2.Tests
{
    /// <summary>
    /// Tests for <see cref="Vowel"/> struct.
    /// </summary>
    [TestClass]
    public class VowelTests
    {
        /// <summary>
        /// Negative test for constructing the struct. 
        /// Unsupported characters result in exception.
        /// </summary>
        /// <param name="input">
        /// Entered char.
        /// </param>
        [DataTestMethod]
        [DataRow('б')]
        [DataRow('+')]
        [DataRow('f')]
        [DataRow('0')]
        [DataRow('%')]
        [ExpectedException(typeof(Exception), "Unknown char received.")]
        public void Constructor_WrongSymbol_Exception(char input)
        {
            var letter = new Vowel(input);
        }
    }
}
