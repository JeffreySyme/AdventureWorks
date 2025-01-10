using AdventureWorks.Models;
using AdventureWorks.Services.SalesOrders;
using Microsoft.Extensions.DependencyInjection;

namespace AdventureWorks.Services;
public partial interface IAdventureWorksServices 
{
    Task<SalesOrderModel?> FindSalesOrderAsync(int salesOrderId);
    IQueryable<SalesOrderModel> QuerySalesOrders();
}
internal partial class AdventureWorksServices : IAdventureWorksServices
{
    public Task<SalesOrderModel?> FindSalesOrderAsync(int salesOrderId) 
    {
        return serviceProvider
            .GetRequiredService<IFindSalesOrder>()
            .ExecuteAsync(salesOrderId);
    }
    public IQueryable<SalesOrderModel> QuerySalesOrders() 
    {
        return serviceProvider
            .GetRequiredService<IQuerySalesOrders>()
            .Execute();
    }
}
