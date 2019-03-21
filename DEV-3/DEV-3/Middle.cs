namespace DEV_3
{
    /// <summary>
    /// Class for Middle type employee
    /// </summary>
    class Middle : Junior
    {
        public Middle()
        {
            Salary = 500;
            Productivity = 25;
            Valuation = (double)Productivity / Salary;
        }
    }
}
