using AdventureWorks.Models;
using AdventureWorks.Services;
using AdventureWorks.Services.Functions;
using Microsoft.AspNetCore.Mvc;

namespace AdventureWorks.Api.Controllers;
[Route("[controller]")]
public class FunctionsController(IAdventureWorksCommandProvider commandProvider) : Controller
{
    [HttpPost("GetProducts")]
    public async Task<IActionResult> GetProducts([FromBody] GetProductsParams request)
    {
        return Ok(await commandProvider.Get<IGetProducts>().ExecuteAsync(request));
    }
}