using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCsv.App.Services;

namespace WebApiCsv.App.Controllers;

[ApiController]
[Route("api/[controller]")]
[Consumes("multipart/form-data")]
public sealed class ItemImportController : ControllerBase
{
	private readonly IItemImportService _service;

	public ItemImportController(IItemImportService service)
	{
		_service = service;
	}
}