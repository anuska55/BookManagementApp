using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
namespace BookManagementApp.Models
{
	public class Book
	{
		// Book Properties (& their validations)
		public int Id { get; set; } // Primary Key

		[Required(ErrorMessage = "Title is required.")]
		[StringLength(100, MinimumLength = 2, ErrorMessage = "Title must be between 2 and 100 " +
			"characters.")]
		public string? Title { get; set; }

		[Required(ErrorMessage = "Author is required.")]
		[StringLength(50, MinimumLength = 2, ErrorMessage = "Author must be between 2 and 50 " +
			"characters.")]
		public string? Author { get; set; }

		[Required(ErrorMessage = "Genre is required.")]
		public string GenreId { get; set; } // Foreign key for Genre

		[ValidateNever]
		public Genre? Genre { get; set; }

		[DateBeforeCurrentYear] // My own validation that inherits from ValidationAttribute class
		public int? Year { get; set; }


		public bool IsAvailable { get; set; }
	}
}
