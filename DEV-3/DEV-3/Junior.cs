namespace DEV_3
{
    /// <summary>
    /// Class for Junior type employee
    /// </summary>
    class Junior : Employee
    {
        public Junior()
        {
            Salary = 250;
            Productivity = 10;
            Valuation = (double) Productivity / Salary;
        }
    }
}
