namespace DEV_3
{
    /// <summary>
    /// Abstract parent class for all employees
    /// </summary>
    abstract class Employee
    {
        public int Salary { get; protected set; }
        public int Productivity { get; protected set; }
        protected double _valuation;

        public double Valuation
        {
            get => _valuation;
            set => _valuation = (double)Productivity / Salary;
        }
    }
}