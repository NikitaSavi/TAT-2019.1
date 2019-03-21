using System;
using System.Collections.Generic;

namespace DEV_3
{
    /// <summary>
    /// Criterion 1: Maximum productivity within the sum
    /// </summary>
    class Criterion1Optimize : OptimalTeamCompiler
    {
        private int AvailableMoney { get; set; }

        public Criterion1Optimize(int availableMoney)
        {
            AvailableMoney = availableMoney;
        }

        public override List<Employee> Choose(List<Employee> listOfEmployees)
        {
            //TODO consider using linear/integer programming
            List<Employee> listOfFoundEmployees = new List<Employee>();
            foreach (var employee in listOfEmployees)
            {
                if (AvailableMoney < employee.Salary) continue;
                switch (employee)
                {
                    case Lead _:
                        listOfFoundEmployees.Add(employee);
                        AvailableMoney -= employee.Salary;
                        continue;
                    case Senior _:
                        listOfFoundEmployees.Add(employee);
                        AvailableMoney -= employee.Salary;
                        continue;
                    case Middle _:
                        listOfFoundEmployees.Add(employee);
                        AvailableMoney -= employee.Salary;
                        continue;
                    case Junior _:
                        listOfFoundEmployees.Add(employee);
                        AvailableMoney -= employee.Salary;
                        break;
                }
            }

            if (listOfFoundEmployees.Count == listOfEmployees.Count &&
                AvailableMoney >= listOfFoundEmployees[listOfFoundEmployees.Count - 1].Salary)
            {
                Console.WriteLine(
                    "Warning - company doesn't have any more employees other than those found. Full optimization that meets your requirements is not possible.");
            }

            if (listOfFoundEmployees.Count == 0)
            {
                throw new Exception("You don't have enough money to hire even the cheapest employee.");
            }

            return listOfFoundEmployees;
        }
    }
}