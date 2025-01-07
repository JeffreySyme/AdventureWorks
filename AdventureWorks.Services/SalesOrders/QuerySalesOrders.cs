using AdventureWorks.Data;
using AdventureWorks.Models;

namespace AdventureWorks.Services.SalesOrders;
internal class QuerySalesOrders(AdventureWorksDbContext db) : IQuery<SalesOrderModel>
{
    public IQueryable<SalesOrderModel> Execute()
    {
        return db.SalesOrderHeaders.ProjectToModel();
    }
}
