namespace DEV_3
{
    /// <summary>
    /// Class for Senior type employee
    /// </summary>
    class Senior : Middle
    {
        public Senior()
        {
            Salary = 1000;
            Productivity = 55;
            Valuation = (double)Productivity / Salary;
        }
    }
}