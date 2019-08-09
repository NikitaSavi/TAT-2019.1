using System;
using System.Collections.Generic;
using System.Linq;

using DEV_3.Employees;

namespace DEV_3.Optimizer
{
    /// <inheritdoc />
    /// <summary>
    /// Criterion 3: Minimum number of staff higher than Junior for required productivity
    /// </summary>
    public class CriterionMinStaff : OptimalTeamCompiler
    {
        /// <summary>
        /// Gets or sets the required productivity.
        /// </summary>
        private int RequiredProductivity { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CriterionMinStaff"/> class.
        /// </summary>
        /// <param name="requiredProductivity">
        /// The required productivity.
        /// </param>
        public CriterionMinStaff(int requiredProductivity)
        {
            this.RequiredProductivity = requiredProductivity;
        }

        /// <summary>
        /// Sorts employees by their productivity, those with higher productivity go to the final list
        /// </summary>
        /// <param name="listOfEmployees">List of all employees</param>
        /// <returns>Compiled list of employees</returns>
        public override List<Employee> Choose(List<Employee> listOfEmployees)
        {
            var sortedListOfEmployees =
                listOfEmployees.OrderByDescending(i => i.Productivity).ToList();
            var listOfFoundEmployees = new List<Employee>();

            foreach (var employee in sortedListOfEmployees)
            {
                if (this.RequiredProductivity >= employee.Productivity && employee.GetType() != typeof(Junior))
                {
                    listOfFoundEmployees.Add(employee);
                    this.RequiredProductivity -= employee.Productivity;
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