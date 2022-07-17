using CurrenciesTaskApi.Data.Interfaces;
using CurrenciesTaskApi.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CurrenciesTaskApi.Controllers
{
    public class CurrencyItemController : Controller
    {
        private readonly ICurrencyRepository currencyRepository;
        private readonly ILogger<CurrencyItemController> logger;
        public CurrencyItemController(ICurrencyRepository currencyRepository, ILogger<CurrencyItemController> logger)
        {
            this.currencyRepository = currencyRepository;
            this.logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> AddRecord(string CurrencyCode, string RateDate)
        {
            var currencyOndate = new Currencies_Ondate();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://www.nbrb.by/api/exrates/rates/{CurrencyCode}?parammode=2&ondate={RateDate}"),
            };
            using (var response = await client.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {
                    var body = await response.Content.ReadAsStringAsync();
                    currencyOndate = JsonConvert.DeserializeObject<Currencies_Ondate>(body);
                    logger.LogInformation($"Success request. CurrencyCode = {CurrencyCode} and RateDate = {RateDate}. Adding record to database...");
                }
                else
                {
                    logger.LogWarning($"Bad request. Attempt to send another request with the current date");
                    var innerRequest = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri($"https://www.nbrb.by/api/exrates/rates/{CurrencyCode}?parammode=2"),
                    };
                    using (var innerResponse = await client.SendAsync(innerRequest))
                    {
                        if (innerResponse.IsSuccessStatusCode)
                        {
                            var body = await innerResponse.Content.ReadAsStringAsync();
                            currencyOndate = JsonConvert.DeserializeObject<Currencies_Ondate>(body);
                            logger.LogInformation($"Success request. CurrencyCode = {CurrencyCode} and RateDate = {DateTime.Now}. Adding record to database...");
                        }
                        else
                        {

                            logger.LogError($"404. Cannot find this resource on API. Please, try to update currencies");
                            return RedirectToAction("Index", "CurrencyList");
                        }
                    }
                }

            }
            currencyOndate.GUID = Guid.NewGuid().ToString();
            currencyOndate.CODE = CurrencyCode;
            await currencyRepository.AddRecord(currencyOndate);
            return RedirectToAction("Index", "CurrencyList");
        }

        public async Task<IActionResult> RemoveRecord(string Guid)
        {
            await currencyRepository.RemoveRecord(Guid);
            return RedirectToAction("Index", "CurrencyList");
        }
    }
}
