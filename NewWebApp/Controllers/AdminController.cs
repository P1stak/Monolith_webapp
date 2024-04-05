using Microsoft.AspNetCore.Mvc;
using NewWebApp.Models;
using System.Diagnostics;

namespace NewWebApp.Controllers
{
	public class AdminController : Controller
	{
		private readonly NewsRepository NewsRepository;

		public AdminController(NewsRepository NewsRepository)
		{
			this.NewsRepository = NewsRepository;
		}

		public IActionResult Index()
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
