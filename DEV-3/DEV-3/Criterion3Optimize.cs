using System;
using System.Collections.Generic;

namespace DEV_3
{
    /// <summary>
    /// Criterion 3: Minimum number of staff higher than Junior for required productivity
    /// </summary>
    class Criterion3Optimize : OptimalTeamCompiler
    {
        private int RequiredProductivity { get; set; }

        public Criterion3Optimize(int requiredProductivity)
        {
            RequiredProductivity = requiredProductivity;
        }

        public override List<Employee> Choose(List<Employee> listOfEmployees)
        {
            //TODO consider using linear/integer programming
            //TODO what exactly Crit.3 is looking for?
            var listOfFoundEmployees = new List<Employee>();
            foreach (var employee in listOfEmployees)
            {
                if (RequiredProductivity < listOfEmployees[listOfEmployees.Count - 1].Productivity) break;
                if (RequiredProductivity < employee.Productivity) continue;
                switch (employee)
                {
                    case Lead _:
                        listOfFoundEmployees.Add(employee);
                        RequiredProductivity -= employee.Productivity;
                        continue;
                    case Senior _:
                        listOfFoundEmployees.Add(employee);
                        RequiredProductivity -= employee.Productivity;
                        continue;
                    case Middle _:
                        listOfFoundEmployees.Add(employee);
                        RequiredProductivity -= employee.Productivity;
                        continue;
                    case Junior _:
                        listOfFoundEmployees.Add(employee);
                        RequiredProductivity -= employee.Productivity;
                        break;
                }
            }

            if (listOfFoundEmployees.Count == listOfEmployees.Count &&
                RequiredProductivity >= listOfFoundEmployees[listOfFoundEmployees.Count - 1].Productivity)
            {
                Console.WriteLine(
                    "Warning - company doesn't have any more employees other than those found. Full optimization that meets your requirements is not possible.");
            }

            if (listOfFoundEmployees.Count == 0)
            {
                throw new Exception("The productivity you require is lower than the one of our cheapest worker.");
            }

            return listOfFoundEmployees;
        }
    }
}