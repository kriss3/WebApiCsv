using FluentValidation;
using WebApiCsv.App.Models;

namespace WebApiCsv.App.Validation;

public class ItemImportRowValidator : AbstractValidator<ItemImportRow>
{
	private static readonly string[] AllowedCategories =
		["Flower", "Concentrate", "Edible", "Topical"];
}
