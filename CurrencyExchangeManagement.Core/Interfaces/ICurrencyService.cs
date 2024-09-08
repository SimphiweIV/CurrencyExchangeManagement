

namespace CurrencyExchangeManagement.Core.Interfaces
{
    public interface ICurrencyService
    {
        Task<decimal> GetExchangeRates(string baseCurrency, string targetCurrency);
    }
}
