namespace ExchangeRatesAssignment.Api.Models
{
    public class ExchangeRate
    {
        public string CurrencyCode { get; set; }
        public string CountryCode { get; set; }   
        public string PaymentMethod { get; set; }
        public string DeliveryMethod {  get; set; }

        private decimal flatRate { get; set; }
        private decimal partnerRate { get; set; }
        public decimal PangeaRate
        {
            get
            {
                return Math.Round(flatRate + partnerRate, 2);
            }
        }

        public ExchangeRate(string currencyCode, string countryCode, string paymentMethod, string deliveryMethod, decimal _flatRate, decimal _partnerRate)
        {
            CurrencyCode = currencyCode;
            CountryCode = countryCode;
            PaymentMethod = paymentMethod;
            DeliveryMethod = deliveryMethod;
            flatRate = _flatRate;
            partnerRate = _partnerRate;

        }
    }
}
