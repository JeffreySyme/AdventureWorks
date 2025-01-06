using AdventureWorks.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace AdventureWorks.Api.Controllers;

public class CustomersController(IAdventureWorksServices services) : ODataController
{
    [EnableQuery]
    public IActionResult Get() 
    {
        return Ok(services.QueryCustomers());
    }

    [EnableQuery]
    public async Task<IActionResult> Get([FromRoute] int key) 
    {
        var customer = await services.FindCustomerAsync(key);

        if (customer == null)
            return NotFound();

        return Ok(customer);
    }
}
