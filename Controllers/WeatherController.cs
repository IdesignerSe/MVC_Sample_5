using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Sample_1;
using MVC_Sample_1.Models;
using Newtonsoft.Json;

namespace MVC_Sample_1.Controllers
{
    public class WeatherController : Controller
    {
        public async Task<IActionResult> Weader(string town)
        {
            Weather weather = await GetWeather(town);
            ViewData["Temperature"] = weather.Current.TempC;
            ViewData["Town"] = weather.Location.Name;
            return PartialView("_Weather");
        }

        private async Task<Weather> GetWeather(string town)
        {
            HttpClient client = new HttpClient();
            Weather weather = null;
            string uri = "http://api.weatherapi.com/v1/current.json?key=acf4e23413a048439bc132919211504&q=";
            string townWeather = uri + "Malmö";

            if (String.IsNullOrEmpty(town))
            {
                townWeather = uri + "Malmö";
            }
            else
            {
                townWeather = uri + town;
            }
            HttpResponseMessage response = await client.GetAsync(townWeather);
            if (response.IsSuccessStatusCode)
            {
                weather = JsonConvert.DeserializeObject<Weather>(await response.Content.ReadAsStringAsync());
            }
            return weather;
        }
    }
}
