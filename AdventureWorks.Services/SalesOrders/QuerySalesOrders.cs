using AdventureWorks.Data;
using AdventureWorks.Models;

namespace AdventureWorks.Services.SalesOrders;
internal interface IQuerySalesOrders : IQuery<SalesOrderModel> { }
internal class QuerySalesOrders(AdventureWorksDbContext db) : IQuerySalesOrders
{
    public IQueryable<SalesOrderModel> Execute()
    {
        return db.SalesOrderHeaders.ProjectToModel();
    }
}
