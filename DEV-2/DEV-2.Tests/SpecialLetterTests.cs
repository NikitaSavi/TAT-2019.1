using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DEV_2.Tests
{
    /// <summary>
    /// Tests for <see cref="SpecialLetter"/> struct.
    /// </summary>
    [TestClass]
    public class SpecialLetterTests
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
        [DataRow('f')]
        [DataRow('а')]
        [DataRow('0')]
        [DataRow('%')]
        [ExpectedException(typeof(Exception), "Unknown char received.")]
        public void Constructor_WrongSymbol_Exception(char input)
        {
            var letter = new SpecialLetter(input);
        }
    }
}
