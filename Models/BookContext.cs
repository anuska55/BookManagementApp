using Microsoft.EntityFrameworkCore;

namespace BookManagementApp.Models
{
	public class BookContext : DbContext
	{
		public BookContext(DbContextOptions<BookContext> options) : base(options) { }

		public DbSet<Book> Books { get; set; }
		public DbSet<Genre> Genres { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Genre>().HasData(
				new Genre { GenreId = "A", Name = "Action" },
				new Genre { GenreId = "C", Name = "Comedy" },
				new Genre { GenreId = "D", Name = "Drama" },
				new Genre { GenreId = "M", Name = "Musical" },
				new Genre { GenreId = "N", Name = "Nature" }
			);

			modelBuilder.Entity<Book>().HasData(
				new Book { Id = 1, Title = "Koala Adventure", Author = "Edward Kolla", GenreId = "A", Year = 2007, IsAvailable = true },
				new Book { Id = 2, Title = "The Sound of Music", Author = "Maria Von Trapp", GenreId = "M", Year = 1950, IsAvailable = true },
				new Book { Id = 3, Title = "Koalas", Author = "Kenneth Kolla", GenreId = "N", Year = 2010, IsAvailable = false },
				new Book { Id = 4, Title = "Koala Comedy", Author = "Edward Kolla", GenreId = "C", Year = 2014, IsAvailable = true },
				new Book { Id = 5, Title = "Koala Drama", Author = "Edward Kolla", GenreId = "D", Year = 2017, IsAvailable = true }
			);
		}
	}
}
