using CurrencyExchangeManagement.Core.Model.Request;


namespace CurrencyExchangeManagement.Core.Interfaces
{
    public interface ICurrencyRepo
    {
        Task SaveRateHistory(string baseCurrency, string targetCurrency, decimal rate);
        Task<List<CurrencyHistoryRequest>> GetRateHistory();
    }
}
