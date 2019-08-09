namespace DEV_3.Employees
{
    /// <summary>
    /// Class for Lead type employee
    /// </summary>
    public class Lead : Senior
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Lead"/> class.
        /// </summary>
        public Lead()
        {
            this.Salary = 1600;
            this.Productivity = 90;
        }
    }
}