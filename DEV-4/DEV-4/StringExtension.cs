using System;

namespace DEV_4
{
    public static class StringExtension
    {
        public static string GenerateGuid()
        {
            return Guid.NewGuid().ToString();
        }

        public static string WithMaxLength(this string value, int maxLength)
        {
            return value?.Substring(0, Math.Min(value.Length, maxLength));
        }
    }
}
