
namespace CurrencyExchangeManagement.Core.Model.Request
{
    public class CurrencyHistoryRequest
    {
        public int Id { get; set; }
        public required string BaseCurrency { get; set; }
        public required string TargetCurrency { get; set; }
        public decimal Rates { get; set; }
        public DateTime DateRequested { get; set; }
    }
}
