using AdventureWorks.Services;
using AdventureWorks.Services.Customers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace AdventureWorks.Api.Controllers;

public class CustomersController(IAdventureWorksCommandProvider commandProvider) : ODataController
{
    [EnableQuery]
    public IActionResult Get() 
    {
        return Ok(commandProvider
            .Get<IQueryCustomers>()
            .Execute());
    }

    [EnableQuery]
    public async Task<IActionResult> Get([FromRoute] int key) 
    {
        var customer = await commandProvider
            .Get<IFindCustomer>()
            .ExecuteAsync(key);

        if (customer == null)
            return NotFound();

        return Ok(customer);
    }
}
