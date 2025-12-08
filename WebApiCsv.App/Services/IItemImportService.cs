namespace WebApiCsv.App.Services;

public interface IItemImportService
{
	/// <summary>
	/// Takes uploaded CSV file, validates and processes each row,
	/// and returns a CSV as byte[] with per-row status.
	/// </summary>
	Task<byte[]> ProcessImportAsync(IFormFile csvFile, CancellationToken cancellationToken = default);

}
