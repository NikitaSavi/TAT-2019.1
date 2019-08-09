namespace DEV_3.Employees
{
    /// <summary>
    /// Class for Senior type employee
    /// </summary>
    public class Senior : Middle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Senior"/> class.
        /// </summary>
        public Senior()
        {
            this.Salary = 1000;
            this.Productivity = 70;
        }
    }
}