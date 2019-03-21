namespace DEV_3
{
    /// <summary>
    /// Class for Lead type employee
    /// </summary>
    class Lead : Senior
    {
        public Lead()
        {
            Salary = 1600;
            Productivity = 90;
            Valuation = (double)Productivity / Salary;
        }

    }
}
