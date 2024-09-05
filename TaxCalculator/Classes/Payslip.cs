namespace TaxCalculator.Classes
{
    public class Payslip
    {
        private string _name;
        public string Name
        {
            get { return _name; }
        }

        private decimal _monthlyGrossIncome;
        public decimal MonthlyGrossIncome
        {
            get { return _monthlyGrossIncome; }
        }

        private decimal _monthlyIncomeTax;
        public decimal MonthlyIncomeTax
        {
            get { return _monthlyIncomeTax; }
        }

        private decimal _monthlyNetIncome;
        public decimal MonthlyNetIncome
        {
            get { return _monthlyNetIncome; }
        }

        public Payslip(string name, decimal monthlyGrossIncome, decimal monthlyIncomeTax, decimal monthlyNetIncome)
        {
            _name = name;
            _monthlyGrossIncome = monthlyGrossIncome;
            _monthlyIncomeTax = monthlyIncomeTax;
            _monthlyNetIncome = monthlyNetIncome;
        }
    }
}
