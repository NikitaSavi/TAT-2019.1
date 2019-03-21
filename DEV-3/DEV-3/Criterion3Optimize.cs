using System;
using System.Collections.Generic;
using System.Linq;

namespace DEV_3
{
    /// <inheritdoc />
    /// <summary>
    /// Criterion 3: Minimum number of staff higher than Junior for required productivity
    /// </summary>
    class Criterion3Optimize : OptimalTeamCompiler
    {
        //TODO redetermine what Crit3 is actually supposed to do
        private int RequiredProductivity { get; set; }

        public Criterion3Optimize(int requiredProductivity)
        {
            RequiredProductivity = requiredProductivity;
        }

        /// <summary>
        /// Sorts employees by their productivity, those with higher productivity go to the final list
        /// </summary>
        /// <param name="listOfEmployees">List of all employees</param>
        /// <returns>Compiled list of employees</returns>
        public override List<Employee> Choose(List<Employee> listOfEmployees)
        {
            var sortedListOfEmployees =
                listOfEmployees.OrderByDescending(i => i.Productivity).ToList(); //list sorted by employees productivity
            var listOfFoundEmployees = new List<Employee>();

            foreach (var employee in sortedListOfEmployees)
            {
                if (RequiredProductivity >= employee.Productivity && employee.GetType() != typeof(Junior))
                {
                    listOfFoundEmployees.Add(employee);
                    RequiredProductivity -= employee.Productivity;
                }
            }

            if (listOfFoundEmployees.Count == listOfEmployees.Count)
            {
                Console.WriteLine(
                    "Warning - all employees of the company are used");
            }

            if (listOfFoundEmployees.Count == 0)
            {
                throw new Exception("Entered productivity is too low");
            }

            return listOfFoundEmployees;
        }
    }
}