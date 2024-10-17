using BookManagementApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookManagementApp.Controllers
{
	public class BookController : Controller
	{
		// Context property of Controller
		public BookContext Context { get; set; }

		// Constructor of the Controller
		public BookController(BookContext context)
		{
			Context = context;
		}

		// BookList (index) page
		public IActionResult BookList()
		{
			var books = Context.Books.Include(b => b.Genre).OrderBy(b => b.Title).ToList();
			return View(books);
		}

		// Book Details page
		public IActionResult Details(int id)
		{
			var book = Context.Books.Include(b => b.Genre).FirstOrDefault(b => b.Id == id);
			return View(book);
		}

		// Adding a Book
		[HttpGet]
		public IActionResult AddBook()
		{
			ViewBag.Genres = Context.Genres.OrderBy(g => g.Name).ToList();
			return View("EditBook", new Book());
		}

		// Editing a Book
		[HttpGet]
		public IActionResult EditBook(int id)
		{
			ViewBag.Genres = Context.Genres.OrderBy(g => g.Name).ToList();
			var bookId = Context.Books.FirstOrDefault(b => b.Id == id);
			return View(bookId);
		}
		[HttpPost]
		public IActionResult EditBook(Book book)
		{
			if (ModelState.IsValid)
			{
				if (book.Id == 0)
				{
					Context.Books.Add(book);
				}
				else
				{
					Context.Books.Update(book);
				}
				Context.SaveChanges();
				return RedirectToAction("BookList");
			}
			else
			{
				ViewBag.Genres = Context.Genres.OrderBy(g => g.Name).ToList();
				return View(book);
			}
		}

		// Deleting a Book
		[HttpGet]
		public IActionResult DeleteBook(int id)
		{
			var bookId = Context.Books.FirstOrDefault(b => b.Id == id);
			return View(bookId);
		}
		[HttpPost]
		public IActionResult DeleteBook(Book book)
		{
			Context.Books.Remove(book);
			Context.SaveChanges();
			return RedirectToAction("BookList");
		}
	}
}
