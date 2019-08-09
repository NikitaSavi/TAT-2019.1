using System.Collections.Generic;

namespace DEV_3
{
    /// <summary>
    /// Abstract parent class for optimization
    /// </summary>
    abstract class OptimalTeamCompiler
    {
        /// <summary>
        /// Compiles the list according to the criterion. Overriden in derived classes.
        /// </summary>
        /// <param name="listOfEmployees">List that contains employees</param>
        /// <returns>List of found according to the criteria employees</returns>
        public abstract List<Employee> Choose(List<Employee> listOfEmployees);
    }
}