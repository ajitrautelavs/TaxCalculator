using TaxCalculator.Classes;
using TaxCalculator.Services;

var input = Console.ReadLine();
if (input == null)
    return;

var inputStrings = input.Split("\" ");
if (inputStrings.Length < 2 )
    return;

var name = inputStrings[0].Trim('\"');

decimal grossAnnualSalary;
if (decimal.TryParse(inputStrings[1], out grossAnnualSalary) == false)
    return;

var employee = new Employee(name, grossAnnualSalary);

var taxBandList = new List<TaxBand> { 
    new TaxBand(0, 20000, 0),
    new TaxBand(20001, 40000, (decimal).1),
    new TaxBand(40001, 80000, (decimal).2),
    new TaxBand(80001, 180000, (decimal).3),
    new TaxBand(180001, Decimal.MaxValue, (decimal).4)
};

var taxCalc = new AnnualTaxCalculator(employee.AnnualSalary, taxBandList);
var service = new PayslipGenerator(employee, taxBandList, taxCalc);
var payslip = service.GeneratePayslip();

Console.WriteLine("Monthly payslip for: \"{0}\"", payslip.Name);
Console.WriteLine("Gross Monthly Income: {0}", payslip.MonthlyGrossIncome);
Console.WriteLine("Monthly Income tax: {0}", payslip.MonthlyIncomeTax);
Console.WriteLine("Net Monthly Income: {0}", payslip.MonthlyNetIncome);

Console.ReadKey();