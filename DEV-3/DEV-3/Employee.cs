namespace DEV_3
{
    /// <summary>
    /// Abstract parent class for all employees
    /// </summary>
    abstract class Employee
    {
        public int Salary { get; protected set; }
        public int Productivity { get; protected set; }
        public double Valuation => (double) Productivity / Salary;
    }
}