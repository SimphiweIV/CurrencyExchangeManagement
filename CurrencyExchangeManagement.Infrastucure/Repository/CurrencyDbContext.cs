

using CurrencyExchangeManagement.Core.Interfaces;
using CurrencyExchangeManagement.Core.Model.Request;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchangeManagement.Infrastucure.Repository
{
    public class CurrencyDbContext : DbContext
    {
        public CurrencyDbContext(DbContextOptions<CurrencyDbContext> options) : base(options) { }

        public DbSet<CurrencyHistoryRequest> RateHistories { get; set; }
    }

    public class CurrencyRepository : ICurrencyRepo
    {
        private readonly CurrencyDbContext _context;

        public CurrencyRepository(CurrencyDbContext context)
        {
            _context = context;
        }


        public async Task<List<CurrencyHistoryRequest>> GetRateHistory()
        {
            return await _context.RateHistories.ToListAsync();
        }

        public async Task SaveRateHistory(string baseCurrency, string targetCurrency, decimal rate)
        {
            var history = new CurrencyHistoryRequest
            {
                BaseCurrency = baseCurrency,
                TargetCurrency = targetCurrency,
                Rates = rate,
                DateRequested = DateTime.UtcNow
            };

            _context.RateHistories.Add(history);
            await _context.SaveChangesAsync();
        }
    }
}
