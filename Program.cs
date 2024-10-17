using BookManagementApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagementApp
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddControllersWithViews();
			builder.Services.AddDbContext<BookContext>(
				Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("BookContext"))
			);
			var app = builder.Build();

			app.UseStaticFiles();

			app.MapControllerRoute("default", "{controller=Book}/{action=AddBook}/{id?}");

			app.Run();
		}
	}
}
