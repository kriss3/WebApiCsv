using FluentValidation;
using WebApiCsv.App.Models;

namespace WebApiCsv.App.Validation;

public class ItemImportRowValidator : AbstractValidator<ItemImportRow>
{
	private static readonly string[] AllowedCategories =
		["Flower", "Concentrate", "Edible", "Topical"];

	public ItemImportRowValidator()
	{
		RuleFor(x => x.ItemName)
			.NotEmpty().WithMessage("ItemName is required.");

		RuleFor(x => x.ItemNumber)
			.NotEmpty().WithMessage("ItemNumber is required.");

		RuleFor(x => x.ItemCategory)
			.NotEmpty().WithMessage("ItemCategory is required.")
			.Must(cat => AllowedCategories.Contains(cat))
			.WithMessage($"ItemCategory must be one of: {string.Join(", ", AllowedCategories)}.");
	}
}
