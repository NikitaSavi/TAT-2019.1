using System;
using System.Collections.Generic;
using System.Linq;

namespace DEV_3
{
    /// <summary>
    /// Class for keeping info about the employees and for calling methods for optimization
    /// </summary>
    class Company
    {
        private List<Employee> ListOfEmployees { get; } = new List<Employee>();
        private int _numOfJuniors = 50;
        private int _numOfMids = 30;
        private int _numOfSeniors = 10;
        private int _numOfLeads = 3;

        /// <summary>
        /// Constructor fills the list of all employees
        /// </summary>
        public Company()
        {
            for (int i = 0; i < _numOfLeads; i++)
            {
                ListOfEmployees.Add(new Lead());
            }

            for (int i = 0; i < _numOfSeniors; i++)
            {
                ListOfEmployees.Add(new Senior());
            }

            for (int i = 0; i < _numOfMids; i++)
            {
                ListOfEmployees.Add(new Middle());
            }

            for (int i = 0; i < _numOfJuniors; i++)
            {
                ListOfEmployees.Add(new Junior());
            }
        }

        /// <summary>
        /// Calls for creation of the optimal list
        /// </summary>
        /// <param name="optimalTeamCompiler">Optimizer class, initialized with the necessary criterion</param>
        /// <returns>List of found according to the criteria employees</returns>
        public List<Employee> GetEmployees(OptimalTeamCompiler optimalTeamCompiler)
        {
            return optimalTeamCompiler.Choose(ListOfEmployees);
        }

        /// <summary>
        /// Shows the number of employees in the provided list
        /// </summary>
        /// <param name="listOfFoundEmployees">List that contains the employees</param>
        public static void ShowNumberOfFoundEmployees(List<Employee> listOfFoundEmployees)
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