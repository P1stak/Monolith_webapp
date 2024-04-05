using Microsoft.AspNetCore.Mvc;
using NewWebApp.Models;

namespace NewWebApp.Controllers
{
	public class GeneralNewsController : Controller
	{
		private readonly NewsRepository NewsRepository;
		public GeneralNewsController(NewsRepository NewsRepository)
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
