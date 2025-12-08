using WebApiCsv.App.Models;
using FluentValidation.Results;

namespace WebApiCsv.App.Validation;

public interface IItemImportValidationEngine
{
	Task<ValidationResult> ValidateAsync(ItemImportRow row, CancellationToken cancellationToken = default);
}
