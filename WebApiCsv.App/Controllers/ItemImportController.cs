using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiCsv.App.Controllers;

[ApiController]
[Route("api/[controller]")]
[Consumes("multipart/")]
public sealed class ItemImportController : ControllerBase
{ }