using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewWebApp.Models;

namespace NewWebApp.Controllers
{
	public class NewsController : Controller
	{

		private readonly NewsRepository NewsRepository;

		public NewsController(NewsRepository NewsRepository)
		{
			this.NewsRepository = NewsRepository;
		}
		public ActionResult Index(Guid id)
		{
			var model = NewsRepository.GetArticles();

			if (id != default)
			{
				return View("Show", NewsRepository.GetArticleById(id));
			}

			return View(model);
		}

	}
}
