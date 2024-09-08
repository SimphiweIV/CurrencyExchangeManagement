using CurrencyExchangeManagement.Core.Interfaces;
using CurrencyExchangeManagement.Infrastucure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyExchangeManagement.API.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;
        private readonly ICurrencyRepo _currencyRepository;

        public CurrencyController(ICurrencyService currencyService, ICurrencyRepo currencyRepository)
        {
            _currencyService = currencyService;
            _currencyRepository = currencyRepository;
        }

        [HttpGet("convert")]
        public async Task<IActionResult> ConvertCurrency(string baseCurrency, string targetCurrency, decimal amount)
        {
            var rate = await _currencyService.GetExchangeRates(baseCurrency, targetCurrency);
            var convertedAmount = amount * rate;

            await _currencyRepository.SaveRateHistory(baseCurrency, targetCurrency, rate);

            return Ok(new { ConvertedAmount = convertedAmount });
        }

        [HttpGet("history")]
        public async Task<IActionResult> GetConversionHistory()
        {
            var history = await _currencyRepository.GetRateHistory();
            return Ok(history);
        }


    }
}
