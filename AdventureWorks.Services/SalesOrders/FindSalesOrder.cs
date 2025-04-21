using AdventureWorks.Data;
using AdventureWorks.Models;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.Services.SalesOrders;
public interface IFindSalesOrder : ICommand<int, SalesOrderModel?> { }
internal class FindSalesOrder(AdventureWorksDbContext db) : IFindSalesOrder
{
    public Task<SalesOrderModel?> ExecuteAsync(int salesOrderId)
    {
        return db.SalesOrderHeaders
            .ProjectToModel()
            .FirstOrDefaultAsync(soh => soh.SalesOrderId == salesOrderId);
    }
}
