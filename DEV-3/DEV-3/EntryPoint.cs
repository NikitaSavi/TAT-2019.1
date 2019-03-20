using System;

namespace DEV_3
{
    class EntryPoint
    {
        static int Main(string[] args)
        {
            try
            {
                //TODO Make console lines prettier, wordier, etc (or is command line input required?)
                int availableMoney, requiredProductivity;
                Console.WriteLine(
                    "Criterias:\n1)Max prod. with your money\n2)Min cost with fixed.prod\n3)Min amount of employees>jun for fixed prod");
                Console.Write("Input: ");

                int.TryParse(Console.ReadLine(), out var criteria);
                switch (criteria)
                {
                    case 1:
                        Console.WriteLine("Money:");
                        int.TryParse(Console.ReadLine(), out availableMoney);
                        //TODO method 1 call
                        break;
                    case 2:
                        Console.WriteLine("Productivity:");
                        int.TryParse(Console.ReadLine(), out requiredProductivity);
                        //TODO method 2 call
                        break;
                    case 3:
                        Console.WriteLine("Productivity:");
                        int.TryParse(Console.ReadLine(), out requiredProductivity);
                        //TODO method 3 call
                        break;
                    //default:
                    //    Console.WriteLine("Unknown input");
                    //    break;
                }

                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error - " + ex.Message);
                return 1;
            }
        }
    }
}
