using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DEV_2.Tests
{
    /// <summary>
    /// Tests for <see cref="Consonant"/> struct.
    /// </summary>
    [TestClass]
    public class ConsonantTests
    {
        /// <summary>
        /// Negative test for constructing the struct.
        /// Unsupported characters result in exception.
        /// </summary>
        /// <param name="input">
        /// Entered char.
        /// </param>
        [DataTestMethod]
        [DataRow('а')]
        [DataRow('ё')]
        [DataRow('+')]
        [DataRow('0')]
        [DataRow('%')]
        [DataRow('f')]
        [ExpectedException(typeof(Exception), "Wrong char received.")]
        public void Constructor_WrongSymbol_Exception(char input)
        {
            var letter = new Consonant(input);
        }
    }
}
