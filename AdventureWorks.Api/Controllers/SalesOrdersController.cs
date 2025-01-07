using AdventureWorks.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace AdventureWorks.Api.Controllers;

public class SalesOrdersController(IAdventureWorksServices services) : ODataController
{
    [EnableQuery]
    public IActionResult Get() 
    {
        return Ok(services.QuerySalesOrders());
    }

    [EnableQuery]
    public async Task<IActionResult> Get([FromRoute] int key) 
    {
        var salesOrder = await services.FindSalesOrderAsync(key);

        if (salesOrder == null)
            return NotFound();

        return Ok(salesOrder);
    }
}
