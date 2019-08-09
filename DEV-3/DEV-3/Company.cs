using System;
using System.Collections.Generic;
using System.Linq;

using DEV_3.Employees;
using DEV_3.Optimizer;

namespace DEV_3
{
    /// <summary>
    /// Class for keeping info about the employees and for calling methods for optimization
    /// </summary>
    public class Company
    {
        /// <summary>
        /// Gets the list of employees.
        /// </summary>
        private List<Employee> ListOfEmployees { get; } = new List<Employee>();

        /// <summary>
        /// The num of juniors.
        /// </summary>
        private readonly int numOfJuniors = 50;

        /// <summary>
        /// The num of mids.
        /// </summary>
        private readonly int numOfMids = 30;

        /// <summary>
        /// The num of seniors.
        /// </summary>
        private readonly int numOfSeniors = 10;

        /// <summary>
        /// The num of leads.
        /// </summary>
        private readonly int numOfLeads = 3;

        /// <summary>
        /// Constructor fills the list of all employees
        /// </summary>
        public Company()
        {
            for (int i = 0; i < this.numOfLeads; i++)
            {
                this.ListOfEmployees.Add(new Lead());
            }

            for (int i = 0; i < this.numOfSeniors; i++)
            {
                this.ListOfEmployees.Add(new Senior());
            }

            for (int i = 0; i < this.numOfMids; i++)
            {
                this.ListOfEmployees.Add(new Middle());
            }

            for (int i = 0; i < this.numOfJuniors; i++)
            {
                this.ListOfEmployees.Add(new Junior());
            }
        }

        /// <summary>
        /// Calls for creation of the optimal list
        /// </summary>
        /// <param name="optimalTeamCompiler">Optimizer class, initialized with the necessary criterion</param>
        /// <returns>List of found according to the criteria employees</returns>
        public List<Employee> GetEmployees(OptimalTeamCompiler optimalTeamCompiler)
        {
            return optimalTeamCompiler.Choose(this.ListOfEmployees);
        }

        /// <summary>
        /// Shows the number of employees in the provided list
        /// </summary>
        /// <param name="listOfFoundEmployees">List that contains the employees</param>
        public void ShowNumberOfFoundEmployees(List<Employee> listOfFoundEmployees)
        {
            Console.WriteLine("The number of employees you'll need:");
            Console.WriteLine(
                $"Junior: {listOfFoundEmployees.Count(x => x.GetType() == typeof(Junior))}" +
                $"\nMiddle: {listOfFoundEmployees.Count(x => x.GetType() == typeof(Middle))}" +
                $"\nSenior: {listOfFoundEmployees.Count(x => x.GetType() == typeof(Senior))}" +
                $"\nLead:   {listOfFoundEmployees.Count(x => x.GetType() == typeof(Lead))}");
        }
    }
}