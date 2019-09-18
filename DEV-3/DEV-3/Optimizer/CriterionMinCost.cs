using System;
using System.Collections.Generic;
using System.Linq;

using DEV_3.Employees;

namespace DEV_3.Optimizer
{
    /// <inheritdoc />
    /// <summary>
    /// Criterion 2: Minimum cost for required productivity
    /// </summary>
    public class CriterionMinCost : OptimalTeamCompiler
    {
        /// <summary>
        /// Gets or sets the required productivity.
        /// </summary>
        private int RequiredProductivity { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CriterionMinCost"/> class.
        /// </summary>
        /// <param name="requiredProductivity">
        /// The required productivity.
        /// </param>
        public CriterionMinCost(int requiredProductivity)
        {
            this.RequiredProductivity = requiredProductivity;
        }

        /// <summary>
        /// Sorts employees by their valuation (product./salary), those with higher valuation go to the final list
        /// </summary>
        /// <param name="listOfEmployees">List of all employees</param>
        /// <returns>Compiled list of employees</returns>
        public override List<Employee> Choose(List<Employee> listOfEmployees)
        {
            var sortedListOfEmployees =
                listOfEmployees.OrderByDescending(i => i.Valuation).ToList();
            var listOfFoundEmployees = new List<Employee>();
           
            foreach (var employee in sortedListOfEmployees.Where(employee => this.RequiredProductivity >= employee.Productivity))
            {
                listOfFoundEmployees.Add(employee);
                this.RequiredProductivity -= employee.Productivity;
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