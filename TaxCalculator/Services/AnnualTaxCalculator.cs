using TaxCalculator.Classes;
using TaxCalculator.Interfaces;

namespace TaxCalculator.Services
{
    public class AnnualTaxCalculator : IAnnualTaxCalculator
    {
        private readonly decimal _grossAnnualSalary;
        private readonly IList<TaxBand> _taxBands;

        public AnnualTaxCalculator(decimal grossAnnualSalary, IList<TaxBand> taxBands)
        {
            _grossAnnualSalary = grossAnnualSalary;
            _taxBands = taxBands;
        }

        public decimal CalculateTax()
        {
            decimal totalTax = 0;

            foreach (TaxBand taxBand in _taxBands)
            {
                if (_grossAnnualSalary > taxBand.LowerLimit)
                {
                    decimal taxableIncome = Math.Min(taxBand.UpperLimit - taxBand.LowerLimit, _grossAnnualSalary - taxBand.LowerLimit);
                    decimal taxForBand = taxableIncome * taxBand.TaxRate;

                    totalTax += Math.Round(taxForBand, 0, MidpointRounding.AwayFromZero);
                }
            }

            return totalTax;
        }
    }
}
