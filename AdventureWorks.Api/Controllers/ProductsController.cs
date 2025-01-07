using AdventureWorks.Models;
using AdventureWorks.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace AdventureWorks.Api.Controllers;

public class ProductsController(IAdventureWorksServices services, IAdventureWorksValidator validator) : ODataController
{
    [EnableQuery]
    public IActionResult Get() 
    {
        return Ok(services.QueryProducts());
    }

    [EnableQuery]
    public async Task<IActionResult> Get([FromRoute] int key) 
    {
        var product = await services.FindProductAsync(key);

        if (product == null)
            return NotFound();

        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ProductModel model) 
    {
        var validationResult = await validator.ValidateAsync(model);

        validationResult.AddToModelState(ModelState);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Created(await services.CreateProductAsync(model));
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromRoute] int key, [FromBody] ProductModel model) 
    {
        model.ProductId = key;

        var validationResult = await validator.ValidateAsync(model);

        validationResult.AddToModelState(ModelState);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Updated(await services.UpdateProductAsync(model));
    }
}
