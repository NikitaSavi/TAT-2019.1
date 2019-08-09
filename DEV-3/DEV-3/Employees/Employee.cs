namespace DEV_3.Employees
{
    /// <summary>
    /// Abstract parent class for all employees
    /// </summary>
    public abstract class Employee
    {
        /// <summary>
        /// Gets or sets the salary.
        /// </summary>
        public int Salary { get; protected set; }

        /// <summary>
        /// Gets or sets the productivity.
        /// </summary>
        public int Productivity { get; protected set; }

        /// <summary>
        /// The valuation.
        /// </summary>
        public double Valuation => (double)this.Productivity / this.Salary;
    }
}