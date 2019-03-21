﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DEV_3
{
    /// <inheritdoc />
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
            var sortedListOfEmployees =
                listOfEmployees.OrderByDescending(i => i.Valuation).ToList(); //list sorted by employees valuation
            var listOfFoundEmployees = new List<Employee>();

            foreach (var employee in sortedListOfEmployees)
            {
                if (AvailableMoney > employee.Salary)
                {
                    listOfFoundEmployees.Add(employee);
                    AvailableMoney -= employee.Salary;
                }
            }

            if (listOfFoundEmployees.Count == listOfEmployees.Count)
            {
                Console.WriteLine(
                    "Warning - all employees of the company are used");
            }

            if (listOfFoundEmployees.Count == 0)
            {
                throw new Exception("You don't have enough money to hire even the cheapest employee.");
            }

            return listOfFoundEmployees;
        }
    }
}