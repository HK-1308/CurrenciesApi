using CurrenciesTaskApi.Data.Interfaces;
using CurrenciesTaskApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CurrenciesTaskApi.Data.Repositories
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly DataContext dataContext;
        private readonly ILogger<CurrencyRepository> logger;

        public CurrencyRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<List<Currencies>> GetAllCurrenciesRecords()
        {
            try
            {
                return await dataContext.Currency.ToListAsync();
            }
            catch(Exception e)
            {
                logger.LogError("Error. Cannot get currencies from the database");
                return new List<Currencies>();
            }
        }

        public async Task<List<Currencies_Ondate>> GetAllCurrenciesOndateRecords()
        {
            try
            {
                return await dataContext.Currencies_Ondates.ToListAsync();
            }
            catch(Exception e)
            {
                logger.LogError("Error. Cannot get currenciesOndate from the database");
                return new List<Currencies_Ondate>();
            }
        }

        public async Task<int> UpdateAllRecords(List<Currencies> currencies)
        {
            try
            {
                if (dataContext.Currency.Count() == 0)
                {
                    await dataContext.Currency.AddRangeAsync(currencies);
                    return await dataContext.SaveChangesAsync();
                }
                else
                {
                    dataContext.Currency.UpdateRange(currencies);
                    return await dataContext.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                logger.LogError("Error. Cannot update currencies in the database");
                return -1;
            }
        }

        public async Task<int> RemoveRecord(string Guid)
        {
            try
            {
                var currency = await dataContext.Currencies_Ondates.FirstOrDefaultAsync(currency => currency.GUID == Guid);
                dataContext.Currencies_Ondates.Remove(currency);
                return await dataContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                logger.LogError($"Error. Cannot remove record with GUID = {Guid} from the database");
                return - 1;
            }
        }

        public async Task<int> AddRecord(Currencies_Ondate currency)
        {
            try
            {
                await dataContext.Currencies_Ondates.AddAsync(currency);
                return await dataContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                logger.LogError($"Error. Cannot add record to the database");
                return -1;
            }
        }


    }
}
