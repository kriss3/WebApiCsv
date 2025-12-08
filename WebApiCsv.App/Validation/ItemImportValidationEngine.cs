using FluentValidation;
using FluentValidation.Results;
using WebApiCsv.App.Models;

namespace WebApiCsv.App.Validation;

public class ItemImportValidationEngine(IValidator<ItemImportRow> validator) : IItemImportValidationEngine
{
	private readonly IValidator<ItemImportRow> _validator = validator;

    public async Task<ValidationResult> ValidateAsync(ItemImportRow row, CancellationToken cancellationToken = default)
		=> await _validator.ValidateAsync(row, cancellationToken);
}
