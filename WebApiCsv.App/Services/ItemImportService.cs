
namespace WebApiCsv.App.Services;

public sealed class ItemImportService : IItemImportService
{
    public Task<byte[]> ProcessImportAsync(IFormFile csvFile, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
