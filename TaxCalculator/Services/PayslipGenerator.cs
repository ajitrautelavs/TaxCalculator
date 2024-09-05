using TaxCalculator.Classes;
using TaxCalculator.Interfaces;

namespace TaxCalculator.Services
{
    public class PayslipGenerator : IPayslipGenerator
    {
        private readonly Employee employee;
        private readonly IList<TaxBand> taxBandList;
        private readonly IAnnualTaxCalculator taxCalculator;

        public PayslipGenerator(Employee emp, IList<TaxBand> taxBands, IAnnualTaxCalculator taxCalc)
        {
            employee = emp;
            taxBandList = taxBands;
            taxCalculator = taxCalc;
        }

        public Payslip GeneratePayslip()
        {
            var annualTax = taxCalculator.CalculateTax();

            decimal monthlySalary = employee.AnnualSalary / 12;
            decimal monthlyTax = annualTax / 12;
            decimal netMonthlyIncome = monthlySalary - monthlyTax;

            var payslip = new Payslip(employee.Name, monthlySalary, monthlyTax, netMonthlyIncome);

            return payslip;
        }
    }
}
