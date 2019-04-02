using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HW_05.Models;
using ServiceReference1;
using ServiceReference;
using System.Net.Http;
using Newtonsoft.Json;

namespace HW_05.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            //var data = await CountryInfo("aruba");
            return View();
        }

        public async Task<IActionResult> NumberConversion(int num)
        {
            var client = new NumberConversionSoapTypeClient(NumberConversionSoapTypeClient.EndpointConfiguration.NumberConversionSoap);
            var response = await client.NumberToDollarsAsync(num);
            ViewData["dollars"] = response.Body.NumberToDollarsResult;

            return View();
        }

        public async Task<IActionResult> TextCasing(string word)
        {
            var client = new TextCasingSoapTypeClient(TextCasingSoapTypeClient.EndpointConfiguration.TextCasingSoap);
            var response = await client.InvertStringCaseAsync(word);
            ViewData["InvertCase"] = response.Body.InvertStringCaseResult;

            return View();
        }

        public async Task<IActionResult> ChuckJoke(string firstName, string lastName)
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("http://api.icndb.com/jokes/random?firstName=Chuck&amp;lastName=Doe");
            var response = JsonConvert.DeserializeObject<ChuckResponse>(json);
            ViewData["ChuckJoke"] = response.Value.Joke;

            return View();
        }

        public async Task<IActionResult> CountryInfo(string country)
        {
            var httpClient = new HttpClient();
            if(country != null)
            {
                var json = await httpClient.GetStringAsync($"https://restcountries.eu/rest/v2/name/{country}?fullText=true");
                try
                {
                    var response = JsonConvert.DeserializeObject<IEnumerable<Country>>(json);
                    ViewData["Country"] = response.ElementAt(0).Capital;
                }
                catch ( Exception ex)
                {

                }
            }
                        
          return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
