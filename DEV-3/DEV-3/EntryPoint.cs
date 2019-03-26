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
        /// <param name="args">
        /// args[0] - criteria
        /// args[1] - money for crit.1
        /// args[2] - productivity for crit.2 and 3
        /// </param>
        /// <returns>
        /// 0 - OK
        /// 1 - error
        /// </returns>
        static int Main(string[] args)
        {
            try
            {
                if (args.Length < 3)
                {
                    throw new Exception("3 arguments are required: criterion, money, productivity");
                }

                int.TryParse(args[0], out var criterion);
                var company = new Company();
                OptimalTeamCompiler optimalTeamCompiler;
                switch (criterion)
                {
                    //Call for appropriate method, depending on the criterion entered
                    case 1:
                        int.TryParse(args[1], out var availableMoney);
                        optimalTeamCompiler = new Criterion1Optimize(availableMoney);
                        break;
                    case 2:
                        int.TryParse(args[2], out var requiredProductivity);
                        optimalTeamCompiler = new Criterion2Optimize(requiredProductivity);
                        break;
                    case 3:
                        int.TryParse(args[2], out requiredProductivity);
                        optimalTeamCompiler = new Criterion3Optimize(requiredProductivity);
                        break;
                    default:
                        throw new Exception("Unknown criteria entered");
                }

                var listOfFoundEmployees = company.GetEmployees(optimalTeamCompiler); //Found staff will be in this list
                Company.ShowNumberOfFoundEmployees(listOfFoundEmployees);
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