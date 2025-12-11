
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

	public async Task<byte[]> ProcessImportAsync(IFormFile csvFile, CancellationToken cancellationToken = default)
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

				// 2. Validation
				var validationResult = await _validationEngine.ValidateAsync(record, cancellationToken);

				if (!validationResult.IsValid)
				{
					rowResult.Status = ItemImportStatus.FailedValidation.ToStatusString();
					rowResult.ErrorMessage = string.Join(
						"; ",
						validationResult.Errors.Select(e => e.ErrorMessage));
				}
				else
				{
					// 3. Third-party call (only on valid rows)
					var thirdPartyResult = await _thirdPartyRepository.SendItemAsync(record, cancellationToken);

					if (thirdPartyResult.IsSuccess)
					{
						rowResult.Status = ItemImportStatus.Success.ToStatusString();
						rowResult.ErrorMessage = string.Empty;
					}
					else
					{
						rowResult.Status = ItemImportStatus.FailedThirdParty.ToStatusString();
						rowResult.ErrorMessage = thirdPartyResult.ErrorMessage
							?? "Unknown error from third-party service.";
					}
				}
				resultRows.Add(rowResult);
			}
		}

		// 4. Build output CSV with Status + ErrorMessage
		using var outputStream = new MemoryStream();
        using var writer = new StreamWriter(outputStream, leaveOpen: true);
		using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
		{
			csvWriter.WriteHeader<ItemImportRowResult>();
			await csvWriter.NextRecordAsync();

			foreach (var row in resultRows)
			{
				cancellationToken.ThrowIfCancellationRequested();
				csvWriter.WriteRecord(row);
				await csvWriter.NextRecordAsync();
			}

			await writer.FlushAsync(cancellationToken);
		}

		return outputStream.ToArray();
	}
}
