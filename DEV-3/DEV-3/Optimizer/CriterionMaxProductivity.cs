using System;
using System.Collections.Generic;
using System.Linq;

using DEV_3.Employees;

namespace DEV_3.Optimizer
{
    /// <inheritdoc />
    /// <summary>
    /// Criterion 1: Maximum productivity within the sum
    /// </summary>
    public class CriterionMaxProductivity : OptimalTeamCompiler
    {
        /// <summary>
        /// Gets or sets the available money.
        /// </summary>
        private int AvailableMoney { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CriterionMaxProductivity"/> class.
        /// </summary>
        /// <param name="availableMoney">
        /// The available money.
        /// </param>
        public CriterionMaxProductivity(int availableMoney)
        {
            this.AvailableMoney = availableMoney;
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

            foreach (var employee in sortedListOfEmployees.Where(employee => this.AvailableMoney >= employee.Salary))
            {
                listOfFoundEmployees.Add(employee);
                this.AvailableMoney -= employee.Salary;
            }

            if (listOfFoundEmployees.Count == listOfEmployees.Count)
            {
                Console.WriteLine(
                    "Warning - all employees of the company are used");
            }

            if (listOfFoundEmployees.Count == 0)
            {
                throw new Exception("Entered money sum is too low");
            }

            return listOfFoundEmployees;
        }
    }
}