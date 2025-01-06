using AdventureWorks.Models;
using AdventureWorks.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace AdventureWorks.Api.Controllers;

public class ProductCategoriesController(IAdventureWorksServices services, IAdventureWorksValidator validator) : ODataController
{
    [EnableQuery]
    public IActionResult Get() 
    {
        return Ok(services.QueryProductCategories());
    }

    [EnableQuery]
    public async Task<IActionResult> Get([FromRoute] int key) 
    {
        var result = await services.FindProductCategoryAsync(key);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ProductCategoryModel model) 
    {
        var validationResult = await validator.ValidateAsync(model);

        validationResult.AddToModelState(ModelState);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await services.CreateProductCategoryAsync(model);

        return Created(result);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromRoute] int key, [FromBody] ProductCategoryModel model) 
    {
        model.ProductCategoryId = key;

        var validationResult = await validator.ValidateAsync(model);

        validationResult.AddToModelState(ModelState);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await services.UpdateProductCategoryAsync(model);

        return Updated(result);
    }
}
