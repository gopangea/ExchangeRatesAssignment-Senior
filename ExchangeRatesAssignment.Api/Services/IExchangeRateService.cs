using ExchangeRatesAssignment.Api.Models;

namespace ExchangeRatesAssignment.Api.Services
{
    public interface IExchangeRateService
    {
        public IEnumerable<ExchangeRate> GetExchangeRates(string countryCode);
    }
}
