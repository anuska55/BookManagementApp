using Microsoft.AspNetCore.Mvc;

namespace BookManagementApp.Controllers
{
	public class BookController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
