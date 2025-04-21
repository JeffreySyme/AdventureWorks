using AdventureWorks.Models;
using AdventureWorks.Services;
using AdventureWorks.Services.ProductCategories;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace AdventureWorks.Api.Controllers;

public class ProductCategoriesController(IAdventureWorksCommandProvider commandProvider, IAdventureWorksValidator validator) : ODataController
{
    [EnableQuery]
    public IActionResult Get() 
    {
        return Ok(commandProvider.Get<IQueryProductCategories>().Execute());
    }

    [EnableQuery]
    public async Task<IActionResult> Get([FromRoute] int key) 
    {
        var result = await commandProvider.Get<IFindProductCategory>().ExecuteAsync(key);

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

        var result = await commandProvider
            .Get<ICreateProductCategory>()
            .ExecuteAsync(model);

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

        var result = await commandProvider
            .Get<IUpdateProductCategory>()
            .ExecuteAsync(model);

        return Updated(result);
    }
}
