using AdventureWorks.Services;
using AdventureWorks.Services.SalesOrders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace AdventureWorks.Api.Controllers;

public class SalesOrdersController(IAdventureWorksCommandProvider commandProvider) : ODataController
{
    [EnableQuery]
    public IActionResult Get() 
    {
        return Ok(commandProvider.Get<IQuerySalesOrders>().Execute());
    }

    [EnableQuery]
    public async Task<IActionResult> Get([FromRoute] int key) 
    {
        var salesOrder = await commandProvider
            .Get<IFindSalesOrder>()
            .ExecuteAsync(key);

        if (salesOrder == null)
            return NotFound();

        return Ok(salesOrder);
    }
}
