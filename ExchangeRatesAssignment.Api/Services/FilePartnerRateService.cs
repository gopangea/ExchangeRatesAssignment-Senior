using ExchangeRatesAssignment.Api.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ExchangeRatesAssignment.Api.Services
{
    public class FilePartnerRateService : PartnerRateService
    {
        public override IEnumerable<PartnerRate> GetPartnerRates()
        {
            return PartnerRates.Instance.RatesList;
        }

        private sealed class PartnerRates
        {
            public IEnumerable<PartnerRate> RatesList { get; private set; }

            private PartnerRates() { }

            private static volatile PartnerRates instance;
            private static object syncRoot = new Object();

            public static PartnerRates Instance
            {
                get
                {
                    if (instance == null)
                    {
                        lock (syncRoot)
                        {
                            if (instance == null)
                            {
                                instance = new PartnerRates();
                                using (var r = new StreamReader("PartnerRates.json"))
                                {
                                    var rates = JsonConvert.DeserializeObject<List<PartnerRate>>(r.ReadToEnd());
                                    instance.RatesList = rates ?? new List<PartnerRate>() { };
                                }
                            }
                        }
                    }
                    return instance;
                }
            }
        }
    }

    
}
