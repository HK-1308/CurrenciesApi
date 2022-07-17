using CurrenciesTaskApi.Data.Models;

namespace CurrenciesTaskApi.Data.ViewModels
{
    public class CurrencyListViewModel
    {
        public List<Currencies> Currencies = new List<Currencies>();

        public List<Currencies_Ondate> Ondates = new List<Currencies_Ondate>();
    }
}
