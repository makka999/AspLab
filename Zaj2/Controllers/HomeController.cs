using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Zaj2.Models;
using Newtonsoft.Json;

namespace Zaj2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var path = "https://api.unsplash.com/photos/?client_id=-sv00aZOMumCZG1YRoh6MOYKeZcNq8l6qYPUt6PZlws";
            var client = new HttpClient();
            var response = await client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var photos = JsonConvert.DeserializeObject<Photos[]>(responseString);

                return View(photos);
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