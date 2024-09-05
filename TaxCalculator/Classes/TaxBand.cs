namespace TaxCalculator.Classes
{
    public class TaxBand
    {
        private decimal _lowerLimit;
        public decimal LowerLimit
        {
            get { return _lowerLimit; }
        }

        private decimal _upperLimit;
        public decimal UpperLimit
        {
            get { return _upperLimit; }
        }

        private decimal _taxRate;
        public decimal TaxRate
        {
            get { return _taxRate; }
        }
        
        public TaxBand(decimal lowerLimit, decimal upperLimit, decimal taxRate)
        {
            _lowerLimit = lowerLimit;
            _upperLimit = upperLimit;
            _taxRate = taxRate;
        }
    }
}
