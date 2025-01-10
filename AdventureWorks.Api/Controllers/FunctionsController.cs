using AdventureWorks.Models;
using AdventureWorks.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdventureWorks.Api.Controllers;
[Route("[controller]")]
public class FunctionsController(IAdventureWorksServices services) : Controller
{
    [HttpPost("GetProducts")]
    public async Task<IActionResult> GetProducts([FromBody] GetProductsParams request)
    {
        return Ok(await services.GetProductsAsync(request));
    }
}