using ExchangeRatesAssignment.Api.Models;

namespace ExchangeRatesAssignment.UnitTests
{
    public class CurrencyUnitTests
    {
        [Fact]
        public void PangeaCurrencyTest_Rounding_IsEqual()
        {
            var exchangeRate = new ExchangeRate("MXN", "MEX", "bankaccount", "debit", 0.024m, 13.412m);
            Assert.Equal(13.44m, exchangeRate.PangeaRate);
        }

        [Fact]
        public void PangeaCurrencyTest_Rounding_NotEqual()
        {
            var exchangeRate = new ExchangeRate("MXN", "MEX", "bankaccount", "debit", 0.024m, 13.412m);
            Assert.NotEqual(13.43m, exchangeRate.PangeaRate);
        }
    }
}