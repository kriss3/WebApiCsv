namespace WebApiCsv.App.Models;

public enum ItemImportStatus
{
	Success,
	FailedValidation,
	FailedThirdParty
}


public static class ItemImportStatusExtensions
{
	public static string ToStatusString(this ItemImportStatus status) =>
		status switch
		{
			ItemImportStatus.Success => "Success",
			ItemImportStatus.FailedValidation => "Failed:Validation",
			ItemImportStatus.FailedThirdParty => "Failed:ThirdParty",
			_ => "Unknown"
		};
}
