using System;

namespace DEV_3
{
    class EntryPoint
    {
        static int Main(string[] args)
        {
            try
            {
                //TODO Make console lines prettier, wordier, etc
                Console.WriteLine(
                    "Criteria:\n1)Max prod. with your money\n2)Min cost with fixed.prod\n3)Min amount of employees>jun for fixed prod");
                Console.Write("Input: ");
                int.TryParse(Console.ReadLine(), out var criteria);

                var company = new Company();
                OptimalTeamCompiler optimalTeamCompiler;

                switch (criteria)
                {
                    case 1:
                        Console.WriteLine("Money:");
                        int.TryParse(Console.ReadLine(), out var availableMoney);
                        optimalTeamCompiler = new Criterion1Optimize(availableMoney);
                        break;
                    case 2:
                        Console.WriteLine("Productivity:");
                        int.TryParse(Console.ReadLine(), out var requiredProductivity);
                        optimalTeamCompiler = new Criterion2Optimize(requiredProductivity);
                        break;
                    case 3:
                        Console.WriteLine("Productivity:");
                        int.TryParse(Console.ReadLine(), out requiredProductivity);
                        optimalTeamCompiler = new Criterion3Optimize(requiredProductivity);
                        break;
                    default:
                        throw new Exception("Unknown input");
                }

                var listOfFoundEmployees = company.GetEmployees(optimalTeamCompiler);
                company.ShowNumberOfFoundEmployees(listOfFoundEmployees);
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