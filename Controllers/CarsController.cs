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
    public class CarsController : Controller
    {
        private readonly VehicleContext _context;

        public CarsController(VehicleContext context)
        {
            _context = context;
        }

        // GET: Cars
        public async Task<IActionResult> Index(string search, string town)
        {
            Weather weather = await GetWeather(town);
            ViewData["Temperature"] = weather.Current.TempC;
            ViewData["Town"] = weather.Location.Name;
            ViewData["Weather"] = weather;


            if (String.IsNullOrEmpty(search))
            {
                return View(await _context.Cars.ToListAsync());
            }
            else
            {
                return View(await _context.Cars.
                    Where(car => car.Brand.Contains(search)
                     || car.Model.Contains(search)
                     || car.Year.ToString().Contains(search)
                    ).ToListAsync());
            }

        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Brand,Model,Year")] Car car)
        {
            if (ModelState.IsValid)
            {
                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Brand,Model,Year")] Car car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.Id == id);
        }

        private async Task<Weather> GetWeather(string town)
        {
            //var culture = new CultureInfo("us-EN");
            //CultureInfo.DefaultThreadCurrentCulture = culture;
            //CultureInfo.DefaultThreadCurrentUICulture = culture;
            HttpClient client = new HttpClient();
            Weather weather = null;
            string uri = "http://api.weatherapi.com/v1/current.json?key=c5b4e15a3a3548dd848121810211702&q=";
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
                //weather = await response.Content.ReadAsAsync<Weather>(new List<MediaTypeFormatter>() { new XmlMediaTypeFormatter { UseXmlSerializer = true }, new JsonMediaTypeFormatter() });
                //var res = await response.Content.ReadAsAsync<Weather>();
                //weather = await JsonSerializer.Deserialize(res);
                //weather = JsonConvert.DeserializeObject<Weather>(await response.Content.ReadAsStringAsync(), new JsonSerializerSettings
                //{
                //    Culture = new System.Globalization.CultureInfo("en-UK")  //Replace tr-TR by your own culture
                //});
                weather = JsonConvert.DeserializeObject<Weather>(await response.Content.ReadAsStringAsync());
            }
            return weather;
        }
    }
}
