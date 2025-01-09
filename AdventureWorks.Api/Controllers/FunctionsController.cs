using AdventureWorks.Models;
using AdventureWorks.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdventureWorks.Api.Controllers;
public class FunctionsController(IAdventureWorksServices services) : Controller
{
    [HttpPost]
    public async Task<IActionResult> GetProducts([FromBody] GetProductsParams request)
    {
        return Ok(await services.GetProductsAsync(request));
    }
}