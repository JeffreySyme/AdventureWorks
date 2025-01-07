using AdventureWorks.Models;
using AdventureWorks.Services.SalesOrders;
using Microsoft.Extensions.DependencyInjection;

namespace AdventureWorks.Services;
internal partial interface IAdventureWorksServices 
{
    Task<SalesOrderModel?> FindSalesOrderAsync(int salesOrderId);
    IQueryable<SalesOrderModel> QuerySalesOrders();
}
internal partial class AdventureWorksServices : IAdventureWorksServices
{
    public Task<SalesOrderModel?> FindSalesOrderAsync(int salesOrderId) 
    {
        return serviceProvider
            .GetRequiredService<FindSalesOrder>()
            .ExecuteAsync(salesOrderId);
    }
    public IQueryable<SalesOrderModel> QuerySalesOrders() 
    {
        return serviceProvider
            .GetRequiredService<QuerySalesOrders>()
            .Execute();
    }
}
