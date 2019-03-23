
namespace DEV_4
{
    public static class StringExtension
    {
        public static int WordCount(this string str, char c)//TODO placeholder for later
        {
            int counter = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == c)
                    counter++;
            }
            return counter;
        }
    }
}
