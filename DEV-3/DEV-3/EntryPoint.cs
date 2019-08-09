using System;

using DEV_3.Optimizer;

namespace DEV_3
{
    /// <summary>
    /// DEV-3: optimize staff using one of the 3 criteria
    /// </summary>
    public class EntryPoint
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
        private static int Main(string[] args)
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
                    case 1:
                        int.TryParse(args[1], out var availableMoney);
                        optimalTeamCompiler = new CriterionMaxProductivity(availableMoney);
                        break;
                    case 2:
                        int.TryParse(args[2], out var requiredProductivity);
                        optimalTeamCompiler = new CriterionMinCost(requiredProductivity);
                        break;
                    case 3:
                        int.TryParse(args[2], out requiredProductivity);
                        optimalTeamCompiler = new CriterionMinStaff(requiredProductivity);
                        break;
                    default:
                        throw new Exception("Unknown criteria entered");
                }

                var listOfFoundEmployees = company.GetEmployees(optimalTeamCompiler);
                new Company().ShowNumberOfFoundEmployees(listOfFoundEmployees);
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