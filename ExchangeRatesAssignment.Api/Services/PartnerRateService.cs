using ExchangeRatesAssignment.Api.Models;

namespace ExchangeRatesAssignment.Api.Services
{
    public abstract class PartnerRateService : IPartnerRateService
    {
        public abstract IEnumerable<PartnerRate> GetPartnerRates();

        public virtual IEnumerable<PartnerRate> GetBestRates()
        {
            List<PartnerRate> output = new List<PartnerRate>();
            foreach (var rate in GetPartnerRates())
            {
                var existing = output.Where(x => x.Currency == rate.Currency && x.PaymentMethod == rate.PaymentMethod && x.DeliveryMethod == rate.DeliveryMethod).FirstOrDefault();
                if (existing == null)
                {
                    output.Add(rate);
                }
                else if (rate.AcquiredDate > existing.AcquiredDate)
                {
                    output[output.IndexOf(existing)] = rate;
                }
            }

            return output;
        }
    }
}
