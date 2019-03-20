using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_3
{
    class Company
    {
        public List<Employee> ListOfEmployees { get; } = new List<Employee>();
        public const int NumOfJuniors = 50;
        public const int NumOfMids = 30;
        public const int NumOfSeniors = 10;
        public const int NumOfLeads = 3;

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

        public List<Employee> GetEmployees(OptimalTeamCompiler optimizer)
        {
            return optimizer.Choose();
        }
    }
}
