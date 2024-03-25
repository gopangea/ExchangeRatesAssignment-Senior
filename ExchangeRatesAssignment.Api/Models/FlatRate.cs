using System.IO.Pipes;

namespace ExchangeRatesAssignment.Api.Models
{
    public class FlatRate
    {
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string CurrencyCode { get; set; }
        public decimal Rate { get; set; }

        public FlatRate(string country, string countryCode, string currencyCode, decimal rate) {
            Country = country;
            CountryCode = countryCode;
            CurrencyCode = currencyCode;
            Rate = rate;        
        }
    }
}
