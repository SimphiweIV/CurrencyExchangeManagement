

using CurrencyExchangeManagement.Core.Interfaces;
using StackExchange.Redis;

namespace CurrencyExchangeManagement.Infrastucure.Services
{
    public class CacheCurrencyService : ICurrencyService
    {
        private readonly ICurrencyService _currencyService;
        private readonly IConnectionMultiplexer _redis;
        private const string RedisKey = "currency_rates";

        public CacheCurrencyService(ICurrencyService currencyService, IConnectionMultiplexer redis)
        {
            _currencyService = currencyService;
            _redis = redis;

        }


        public async Task<decimal> GetExchangeRates(string baseCurrency, string targetCurrency)
        {
            var db = _redis.GetDatabase();
            var cacheRate = await db.StringGetAsync($"{RedisKey}_{baseCurrency}_{targetCurrency}");

            if (!string.IsNullOrWhiteSpace(cacheRate))
            {
                return decimal.Parse(cacheRate);
            }

            var rate = await _currencyService.GetExchangeRates(baseCurrency, targetCurrency);

            await db.StringSetAsync($"{RedisKey}_{baseCurrency}_{targetCurrency}", rate.ToString(), TimeSpan.FromMinutes(15));

            return decimal.Parse(rate.ToString());
        }
    }
}
