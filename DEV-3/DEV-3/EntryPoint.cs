using System;

namespace DEV_3
{
    /// <summary>
    /// DEV-3: optimize staff using one of the 3 criteria
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// Entry point to the program
        /// </summary>
        /// <param name="args"></param>
        /// <returns>
        /// 0 - OK
        /// 1 - error
        /// </returns>
        static int Main(string[] args)
        {
            try
            {
                //TODO Make console lines prettier, wordier, etc
                Console.WriteLine(
                    "Enter a criteria number, which you'd like us to use for optimizing your team:");
                Console.Write(
                    "1) Maximum productivity within the sum\n2) Minimum cost for required productivity.\n3) Minimum number of staff higher than Junior for required productivity.");
                Console.Write("Your input: ");
                int.TryParse(Console.ReadLine(), out var criterion);

                var company = new Company();
                OptimalTeamCompiler optimalTeamCompiler;

                switch (criterion)
                {
                    //Call for appropriate method, depending on the criterion entered
                    case 1:
                        Console.WriteLine("Enter the amount of money limit:");
                        int.TryParse(Console.ReadLine(), out var availableMoney);
                        optimalTeamCompiler = new Criterion1Optimize(availableMoney);
                        break;
                    case 2:
                        Console.WriteLine("Enter the required productivity:");
                        int.TryParse(Console.ReadLine(), out var requiredProductivity);
                        optimalTeamCompiler = new Criterion2Optimize(requiredProductivity);
                        break;
                    case 3:
                        Console.WriteLine("Enter the required productivity:");
                        int.TryParse(Console.ReadLine(), out requiredProductivity);
                        optimalTeamCompiler = new Criterion3Optimize(requiredProductivity);
                        break;
                    default:
                        throw new Exception("Unknown criteria entered");
                }

                var listOfFoundEmployees = company.GetEmployees(optimalTeamCompiler); //Found staff will be in this list
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