using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Reflection;
using System.Xml.Linq;
using Zaj1.Models;

namespace Zaj1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult DisplayNews(int page = 1, int pageSize = 6)
        {
            var rss = XElement.Load("https://news.google.com/rss?topic=w&hl=pl&gl=PL&ceid=PL:pl%22");
            var news = rss.Descendants("item").Select(n => new RssItem
            {
                Title = n.Element("title").Value,
                PubDate = n.Element("pubDate").Value,
                Description = n.Element("description").Value
            }).ToList();
            var pagedData = news.Skip((page - 1) * pageSize).Take(pageSize); 
            var totalPages = Math.Ceiling((double)news.Count() / pageSize); 
            ViewBag.TotalPages = totalPages;
            ViewBag.CurrentPage = page;
            return View(pagedData);

            return View(news);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}