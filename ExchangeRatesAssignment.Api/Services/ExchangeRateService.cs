using ExchangeRatesAssignment.Api.Controllers;
using ExchangeRatesAssignment.Api.Models;

namespace ExchangeRatesAssignment.Api.Services
{
    public class ExchangeRateService : IExchangeRateService
    {
        private readonly IPartnerRateService _partnerRateService;

        public ExchangeRateService(IPartnerRateService partnerRateService)
        {
            _partnerRateService = partnerRateService;
        }

        // make factory pattern
        public List<FlatRate> FlatRates = new List<FlatRate>
        {
            new FlatRate("Mexico", "MEX", "MXN", 0.024m),
            new FlatRate("India", "IND", "INR", 3.213m),
            new FlatRate("Philippines", "PHL", "PHP", 2.437m),
            new FlatRate("Guatemala", "GTM", "GTQ", 0.056m),
        };

        public IEnumerable<ExchangeRate> GetExchangeRates(string countryCode)
        {
            var partnerRates = _partnerRateService.GetBestRates();

            var output = from p in partnerRates
                         join f in FlatRates
                         on p.Currency equals f.CurrencyCode
                         where f.CountryCode == countryCode.ToUpper()
                         select new ExchangeRate(f.CurrencyCode, f.CountryCode, p.PaymentMethod, p.DeliveryMethod, f.Rate, p.Rate);

            return output;
        }
    }

}
