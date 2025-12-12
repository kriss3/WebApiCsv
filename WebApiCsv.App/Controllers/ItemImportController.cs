using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCsv.App.Services;

namespace WebApiCsv.App.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class ItemImportController : ControllerBase
{
	private readonly IItemImportService _service;

	public ItemImportController(IItemImportService service)
	{
		_service = service;
	}

	[HttpPost("import")]
	[Consumes("multipart/form-data")]
	public async Task<IActionResult> Import([FromForm] IFormFile file, CancellationToken cancellationToken)
	{ 
	
	
	}
}