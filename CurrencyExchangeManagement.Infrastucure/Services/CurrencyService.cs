

using CurrencyExchangeManagement.Core.Interfaces;
using CurrencyExchangeManagement.Core.Model.Response;
using System.Net.Http.Json;

namespace CurrencyExchangeManagement.Infrastucure.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly HttpClient _httpClient;

        public CurrencyService(HttpClient httpClient) { _httpClient = httpClient; }

        public async Task<decimal> GetExchangeRates(string baseCurrency, string targetCurrency)
        {
            var response = await _httpClient.GetAsync($"https://api.exchangeratesapi.io/latest?base={baseCurrency}&symbols={targetCurrency}");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadFromJsonAsync<ExchangeResponse>();
            return data.Rates[targetCurrency];
        }
    }
}
