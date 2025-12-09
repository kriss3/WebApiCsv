
using WebApiCsv.App.Repositories;
using WebApiCsv.App.Validation;

namespace WebApiCsv.App.Services;

public sealed class ItemImportService : IItemImportService
{
	private readonly IItemImportValidationEngine _validationEngine;
	private readonly IThirdPartyItemRepository _thirdPartyRepository;

    public ItemImportService(
        IItemImportValidationEngine validationEngine,
		IThirdPartyItemRepository thirdPartyRepository)
    {
        _validationEngine = validationEngine;
        _thirdPartyRepository = thirdPartyRepository;
    }

    public Task<byte[]> ProcessImportAsync(IFormFile csvFile, CancellationToken cancellationToken = default)
    {
        
    }
}
