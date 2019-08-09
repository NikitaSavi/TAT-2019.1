namespace DEV_3.Employees
{
    /// <summary>
    /// Class for Junior type employee
    /// </summary>
    public class Junior : Employee
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Junior"/> class.
        /// </summary>
        public Junior()
        {
            this.Salary = 250;
            this.Productivity = 10;
        }
    }
}
