using WebApiCsv.App.Models;

namespace WebApiCsv.App.Repositories;

public sealed record ThirdPartyResult(bool IsSuccess, string? ErrorMessage);

public interface IThirdPartyItemRepository
{
	Task<ThirdPartyResult> SendItemAsync(ItemImportRow row, CancellationToken cancellationToken = default);
}