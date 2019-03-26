using System;

namespace DEV_4
{
    /// <summary>
    /// Class for string extension methods
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Generates GUID and passes it as a string
        /// </summary>
        /// <param name="str">String to write a GUID in</param>
        /// <returns>GUID as a string</returns>
        public static string GenerateGuid(this string str)
        {
            return Guid.NewGuid().ToString();
        }
        /// <summary>
        /// Additional checks if a string exceeds it's limit
        /// </summary>
        /// <param name="value">A string</param>
        /// <param name="maxLength">Char. limit for a string</param>
        /// <returns>Same string if limit is not exceeded, exception otherwise</returns>
        public static string WithMaxLength(this string value, int maxLength)
        {
            return value?.Length <= maxLength || (value == null)
                ? value
                : throw new Exception("Exceeding symbol limit");
        }
    }
}
