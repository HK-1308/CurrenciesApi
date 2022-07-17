using CurrenciesTaskApi.Data.Interfaces;
using CurrenciesTaskApi.Data.Models;
using CurrenciesTaskApi.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CurrenciesTaskApi.Controllers
{
    public class CurrencyListController : Controller
    {
        private readonly ICurrencyRepository currencyRepository;
        private readonly ILogger<CurrencyListController> logger;
        public CurrencyListController(ICurrencyRepository currencyRepository)
        {
            this.currencyRepository = currencyRepository;
        }

        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            if (String.IsNullOrEmpty(sortOrder))
            {
                ViewBag.CurrencySortParam = "Currency";
                ViewBag.DateSortParam = "Date";
            }
            if(sortOrder == "Currency")
            {
                ViewBag.CurrencySortParam = "CurrencyDesc";
            }
            if(sortOrder == "Date")
            {
                ViewBag.DateSortParam = "DateDesc";
            }
            if (sortOrder == "CurrencyDesc")
            {
                ViewBag.CurrencySortParam = "Currency";
            }
            if (sortOrder == "DateDesc")
            {
                ViewBag.DateSortParam = "Date";
            }
            var model = new CurrencyListViewModel();
            model.Currencies = await currencyRepository.GetAllCurrenciesRecords();
            model.Ondates = await currencyRepository.GetAllCurrenciesOndateRecords();
            model.Ondates.Reverse();
            if (!String.IsNullOrEmpty(searchString))
            {
                model.Ondates = model.Ondates.Where(s => s.CODE.Contains(searchString)
                                       || s.Date.ToString().Contains(searchString)).ToList();
            }
            switch (sortOrder)
            {
                case "Currency": model.Ondates = model.Ondates.OrderBy(ondate => ondate.CODE).ToList(); break;
                case "CurrencyDesc": model.Ondates = model.Ondates.OrderByDescending(ondate => ondate.CODE).ToList(); break;
                case "Date": model.Ondates = model.Ondates.OrderBy(ondate => ondate.Date).ToList(); break;
                case "DateDesc": model.Ondates = model.Ondates.OrderByDescending(ondate => ondate.Date).ToList(); break;
            }

            return View(model);
        }

        public async Task<IActionResult> Update()
        {
            var currencyList = new List<Currencies>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://www.nbrb.by/api/exrates/currencies"),
            };
            using (var response = await client.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {
                    var body = await response.Content.ReadAsStringAsync();
                    currencyList = JsonConvert.DeserializeObject<List<Currencies>>(body);
                }
                else 
                {
                    logger.LogError("Bad request to API. Can't get the list of currencies");
                    return RedirectToAction("Index");
                }
            }
            await currencyRepository.UpdateAllRecords(currencyList);
            return RedirectToAction("Index");
        }
    }
}
