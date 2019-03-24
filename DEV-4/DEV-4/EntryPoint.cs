using System;

namespace DEV_4
{
    class EntryPoint
    {
        //TODO Connect Seminars/Labs to Lectures and to discipline
        static int Main(string[] args)
        {
            try
            {
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return 1;
            }
        }
    }
}