namespace DEV_3.Employees
{
    /// <summary>
    /// Class for Middle type employee
    /// </summary>
    public class Middle : Junior
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Middle"/> class.
        /// </summary>
        public Middle()
        {
            this.Salary = 500;
            this.Productivity = 25;
        }
    }
}
