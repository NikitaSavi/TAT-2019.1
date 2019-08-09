using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DEV_2.Tests
{
    /// <summary>
    /// Tests for <see cref="Letter"/> class.
    /// </summary>
    [TestClass]
    public class LetterTests
    {
        /// <summary>
        /// Negative test for constructing the class. 
        /// Unsupported characters result in exception.
        /// </summary>
        /// <param name="input">
        /// Entered char.
        /// </param>
        [DataTestMethod]
        [DataRow('m')]
        [DataRow('0')]
        [DataRow('_')]
        [DataRow('%')]
        [ExpectedException(typeof(Exception), "Unknown char received.")]
        public void Constructor_WrongSymbol_Exception(char input)
        {
            var letter = new Letter(input);
        }

        /// <summary>
        /// Positive test for constructing the class. 
        /// </summary>
        /// <param name="input">
        /// Entered char.
        /// </param>
        [DataTestMethod]
        [DataRow('а')]
        [DataRow('б')]
        [DataRow('ъ')]
        [DataRow('+')]
        public void Constructor_RightSymbol_Exception(char input)
        {
            var letter = new Letter(input);
        }
    }
}
