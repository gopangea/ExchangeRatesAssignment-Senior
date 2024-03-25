using ExchangeRatesAssignment.Api.Models;

namespace ExchangeRatesAssignment.Api.Services
{
    public interface IPartnerRateService
    {
        IEnumerable<PartnerRate> GetPartnerRates();
        IEnumerable<PartnerRate> GetBestRates();
    }
}
