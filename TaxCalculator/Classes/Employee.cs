namespace TaxCalculator.Classes
{
    public class Employee
    {
        private string _name;
        public string Name
        {
            get { return _name; }
        }

        private decimal _annualSalary;
        public decimal AnnualSalary
        {
            get { return _annualSalary; }
        }

        public Employee(string name, decimal annualSalary)
        {
            _name = name;
            _annualSalary = annualSalary;
        }
    }
}
