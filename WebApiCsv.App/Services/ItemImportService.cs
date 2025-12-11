
using System.Globalization;
using WebApiCsv.App.Models;
using WebApiCsv.App.Repositories;
using WebApiCsv.App.Validation;
using CsvHelper;
using CsvHelper.Configuration;

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
		if (csvFile is null || csvFile.Length == 0)
			throw new ArgumentException("CSV file is required.", nameof(csvFile));

		var resultRows = new List<ItemImportRowResult>();

		// 1. Read input CSV
		using (var stream = csvFile.OpenReadStream())
		using (var reader = new StreamReader(stream))
		{
			var config = new CsvConfiguration(CultureInfo.InvariantCulture)
			{
				HasHeaderRecord = true,
				TrimOptions = TrimOptions.Trim,
				IgnoreBlankLines = true
			};

			using var csv = new CsvReader(reader, config);

			var records = csv.GetRecords<ItemImportRow>();

			foreach (var record in records)
			{
				cancellationToken.ThrowIfCancellationRequested();

				var rowResult = new ItemImportRowResult
				{
					ItemName = record.ItemName,
					ItemNumber = record.ItemNumber,
					ItemCategory = record.ItemCategory,
					Quantity = record.Quantity
				};

			}
		}
	}
}
