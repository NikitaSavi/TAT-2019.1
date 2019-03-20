using System;
using System.Collections.Generic;

namespace DEV_3
{
    class EntryPoint
    {
        static int Main(string[] args)
        {
            try
            {
                //TODO Make console lines prettier, wordier, etc (or is command line input required?)
                Company company = new Company();
                OptimalTeamCompiler optimalTeamCompiler;
                List<Employee> listOfFoundEmployees = new List<Employee>();

                Console.WriteLine(
                    "Criteria:\n1)Max prod. with your money\n2)Min cost with fixed.prod\n3)Min amount of employees>jun for fixed prod");
                Console.Write("Input: ");
                int.TryParse(Console.ReadLine(), out var criteria);
                Console.WriteLine("\nProductivity:");
                int.TryParse(Console.ReadLine(), out var requiredProductivity);
                Console.WriteLine("\nMoney:");
                int.TryParse(Console.ReadLine(), out var availableMoney);
                switch (criteria)
                {
                    case 1:
                        optimalTeamCompiler = new Criteria1Optimize();
                        break;
                    case 2:
                        optimalTeamCompiler = new Criteria2Optimize();
                        break;
                    case 3:
                        optimalTeamCompiler = new Criteria3Optimize();
                        break;
                    default:
                        throw new Exception("Unknown input");
                }

                listOfFoundEmployees = company.GetEmployees(optimalTeamCompiler);
                Console.WriteLine("\nThe number of employees you'll need:");
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