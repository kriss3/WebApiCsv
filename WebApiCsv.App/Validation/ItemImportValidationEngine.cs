using System.ComponentModel.DataAnnotations;
using WebApiCsv.App.Models;

namespace WebApiCsv.App.Validation;

public class ItemImportValidationEngine : IItemImportValidationEngine
{
    public Task<ValidationResult> ValidateAsync(ItemImportRow row, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
