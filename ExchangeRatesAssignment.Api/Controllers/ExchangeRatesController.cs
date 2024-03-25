using ExchangeRatesAssignment.Api.Models;
using ExchangeRatesAssignment.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeRatesAssignment.Api.Controllers
{
    [ApiController]
    [Route("Api/Exchange-Rates")]
    public class ExchangeRatesController : ControllerBase
    {
        private readonly IExchangeRateService _exchangeRateService;

        public ExchangeRatesController(IExchangeRateService exchangeRateService)
        {
            _exchangeRateService = exchangeRateService;
        }

        [HttpGet]
        public IEnumerable<ExchangeRate> Get(string country) {
            //if (country.Length != 3) throw new HttpException(400, "Country code must be 3 letters e.g., MEX or PHL.");
            
            return _exchangeRateService.GetExchangeRates(country);
        }        
    }
}
