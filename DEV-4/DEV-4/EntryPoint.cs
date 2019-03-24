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
                var a = new Discipline();
                var b = new Discipline();
                Console.WriteLine(a.Equals(b));
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