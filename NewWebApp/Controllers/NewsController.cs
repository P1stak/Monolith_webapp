using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
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

		public IActionResult NewsEdit(Guid id)
		{
			//либо создаем новую статью, либо выбираем существующую и передаем в качестве модели в представление
			News model = id == default ? new News() : NewsRepository.GetArticleById(id);
			return View(model);
		}

		[HttpPost] //в POST-версии метода сохраняем/обновляем запись в БД
		public IActionResult NewsEdit(News model)
		{
			//if (ModelState.IsValid)
			//{
			//	NewsRepository.SaveArticle(model);
			//	return RedirectToAction("Index");
			//}
			//return View(model);
			NewsRepository.SaveArticle(model);
			return RedirectToAction("Index");
		}

		[HttpPost] //т.к. удаление статьи изменяет состояние приложения, нельзя использовать метод GET
		public IActionResult NewsDelete(Guid id)
		{
			NewsRepository.DeleteArticle(new News() { Id = id });
			return RedirectToAction("Index");
		}
	}
}
