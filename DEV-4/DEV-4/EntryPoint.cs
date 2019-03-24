using System;

namespace DEV_4
{
    class EntryPoint
    {//TODO get better way to set descriptions. Or don't
        static int Main(string[] args)
        {
            try
            {
                var a =new Discipline("a");
                var b = new Discipline("b", "c");
                Console.WriteLine(b.ToString()+"\n"+a.Equals(b));
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