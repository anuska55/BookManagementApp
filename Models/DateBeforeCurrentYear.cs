using System.ComponentModel.DataAnnotations;

namespace BookManagementApp.Models
{
	/*
	 * REFERENCE: Shyju, StackOverflow contributor
	 * LINK: https://stackoverflow.com/questions/46184818/dataanotation-to-validate-a-model-how-do-i-validate-it-so-that-the-date-is-
	 * NOTE: An excellent resource; very helpful
	 */

	/// <summary>
	/// Validation class that validates the year so that it is between 1000 and the current year.
	/// </summary>
	public class DateBeforeCurrentYear : ValidationAttribute
	{
		/// <summary>
		/// Overrides the FormatErrorMessage string to show the user the year range message
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public override string FormatErrorMessage(string name)
		{
			return "Year must be between 1000 and the current year.";
		}

		/// <summary>
		/// Overrides the IsValid method to validate that the year falls between 1000 and the current year
		/// </summary>
		/// <param name="objValue"></param>
		/// <param name="validationContext"></param>
		/// <returns></returns>
		protected override ValidationResult? IsValid(object? objValue, ValidationContext validationContext)
		{
			int thisYear = DateTime.Now.Year;
			var yearValue = objValue as int? ?? thisYear;

			if (yearValue < 1000 || yearValue > thisYear)
			{
				return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
			}

			return ValidationResult.Success;
		}
	}
}
