namespace WebApiCsv.App.Models;

public sealed class ItemImportRow
{
	public string ItemName { get; set; } = string.Empty;
	public string ItemNumber { get; set; } = string.Empty;
	public string ItemCategory { get; set; } = string.Empty;
	public decimal? Quantity { get; set; }
}
