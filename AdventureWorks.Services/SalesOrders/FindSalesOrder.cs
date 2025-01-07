using AdventureWorks.Data;
using AdventureWorks.Models;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.Services.SalesOrders;
internal class FindSalesOrder(AdventureWorksDbContext db) : ICommand<int, SalesOrderModel?>
{
    public Task<SalesOrderModel?> ExecuteAsync(int salesOrderId)
    {
        return db.SalesOrderHeaders
            .ProjectToModel()
            .FirstOrDefaultAsync(soh => soh.SalesOrderId == salesOrderId);
    }
}
