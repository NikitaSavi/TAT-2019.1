using System;
using System.Collections.Generic;

namespace DEV_3
{
    /// <summary>
    /// Class for keeping info about the employees and for calling methods for optimization
    /// </summary>
    class Company
    {
        private List<Employee> ListOfEmployees { get; } = new List<Employee>();
        private const int NumOfJuniors = 50;
        private const int NumOfMids = 30;
        private const int NumOfSeniors = 10;
        private const int NumOfLeads = 3;

        /// <summary>
        /// Constructor fills the list of all employees
        /// </summary>
        public Company()
        {
            for (int i = 0; i < NumOfLeads; i++)
            {
                ListOfEmployees.Add(new Lead());
            }

            for (int i = 0; i < NumOfSeniors; i++)
            {
                ListOfEmployees.Add(new Senior());
            }

            for (int i = 0; i < NumOfMids; i++)
            {
                ListOfEmployees.Add(new Middle());
            }

            for (int i = 0; i < NumOfJuniors; i++)
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
            var counter = new int[4];
            foreach (var employee in listOfFoundEmployees)
            {
                switch (employee)
                {
                    case Lead _:
                        counter[3]++;
                        break;
                    case Senior _:
                        counter[2]++;
                        break;
                    case Middle _:
                        counter[1]++;
                        break;
                    case Junior _:
                        counter[0]++;
                        break;
                }
            }

            Console.WriteLine("The number of employees you'll need:");
            Console.WriteLine(
                $"Junior: {counter[0]}\nMiddle: {counter[1]}\nSenior: {counter[2]}\nLead:   {counter[3]}");
        }
    }
}