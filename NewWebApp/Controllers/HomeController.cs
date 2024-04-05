using Microsoft.AspNetCore.Mvc;
using NewWebApp.Models;
using System.Diagnostics;

namespace NewWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly NewsRepository NewsRepository;

        public HomeController(ILogger<HomeController> logger, NewsRepository NewsRepository)
        {
            _logger = logger;
            this.NewsRepository = NewsRepository;   
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
		public IActionResult Admin()
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
