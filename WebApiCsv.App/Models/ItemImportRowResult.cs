namespace WebApiCsv.App.Models;

public sealed class ItemImportRowResult
{
	// Original columns
	public string ItemName { get; set; } = string.Empty;
	public string ItemNumber { get; set; } = string.Empty;
	public string ItemCategory { get; set; } = string.Empty;
	public decimal? Quantity { get; set; }

	// Feedback columns
	public string Status { get; set; } = string.Empty; 
	public string ErrorMessage { get; set; } = string.Empty; 
}
