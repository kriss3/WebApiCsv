using System.ComponentModel.DataAnnotations;
using WebApiCsv.App.Models;

namespace WebApiCsv.App.Validation;

public interface IItemImportValidationEngine
{
	Task<ValidationResult> ValidateAsync(ItemImportRow row, CancellationToken cancellationToken = default);
}
