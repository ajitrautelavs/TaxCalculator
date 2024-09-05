using Moq;
using TaxCalculator.Classes;
using TaxCalculator.Services;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            var employee = new Employee("Ajit Rautela", (decimal)60000);
            List<TaxBand> taxBandList = new List<TaxBand> {
                new TaxBand(0, 20000, 0),
                new TaxBand(20001, 40000, (decimal).1),
                new TaxBand(40001, 80000, (decimal).2),
                new TaxBand(80001, 180000, (decimal).3),
                new TaxBand(180001, Decimal.MaxValue, (decimal).4)
            };

            var taxCalc = new AnnualTaxCalculator(employee.AnnualSalary, taxBandList);

            // Act
            var service = new PayslipGenerator(employee, taxBandList, taxCalc);
            var payslip = service.GeneratePayslip();

            // Assert
            Assert.AreEqual("Ajit Rautela", payslip.Name, true);
            Assert.AreEqual(5000, payslip.MonthlyGrossIncome, 0);
            Assert.AreEqual(500, payslip.MonthlyIncomeTax, 0);
            Assert.AreEqual(4500, payslip.MonthlyNetIncome, 0);
        }

        [TestMethod]
        public void TestMethod2()
        {
            // Arrange
            var employee = new Employee("Ajit Rautela", (decimal)60000);
            Mock<List<TaxBand>> mockTaxBands = new Mock<List<TaxBand>>();
            Mock<AnnualTaxCalculator> mockTaxCalculator = new Mock<AnnualTaxCalculator>(MockBehavior.Loose, [employee.AnnualSalary, mockTaxBands.Object]);

            // Act
            var service = new PayslipGenerator(employee, mockTaxBands.Object, mockTaxCalculator.Object);
            var payslip = service.GeneratePayslip();

            // Assert
            Assert.AreEqual("Ajit Rautela", payslip.Name, true);
            Assert.AreEqual(5000, payslip.MonthlyGrossIncome, 0);
            Assert.AreEqual(0, payslip.MonthlyIncomeTax, 0);
            Assert.AreEqual(5000, payslip.MonthlyNetIncome, 0);
        }
    }
}