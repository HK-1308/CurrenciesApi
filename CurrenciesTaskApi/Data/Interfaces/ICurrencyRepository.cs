using CurrenciesTaskApi.Data.Models;

namespace CurrenciesTaskApi.Data.Interfaces
{
    public interface ICurrencyRepository
    {
        public Task<int> UpdateAllRecords(List<Currencies> currencies);

        public Task<List<Currencies>> GetAllCurrenciesRecords();

        public Task<List<Currencies_Ondate>> GetAllCurrenciesOndateRecords();

        public Task<int> RemoveRecord(string Guid);

        public Task<int> AddRecord(Currencies_Ondate currencies);
    }
}
