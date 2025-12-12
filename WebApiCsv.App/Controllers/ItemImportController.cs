using Microsoft.AspNetCore.Mvc;
using WebApiCsv.App.Services;

namespace WebApiCsv.App.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class ItemImportController(IItemImportService service) : ControllerBase
{
	private readonly IItemImportService _service = service;

    [HttpPost("import")]
	[Consumes("multipart/form-data")]
	public async Task<IActionResult> Import([FromForm] IFormFile file, CancellationToken cancellationToken)
	{
		if (file is null || file.Length == 0)
			return BadRequest("File is required.");

		var bytes = await _service.ProcessImportAsync(file, cancellationToken);
		var outName = $"import-result-{DateTime.UtcNow:yyyyMMddHHmm}.csv";

		return File(bytes, "text/csv", outName);
	}
}