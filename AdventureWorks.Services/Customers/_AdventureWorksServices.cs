using AdventureWorks.Models;
using AdventureWorks.Services.Customers;
using Microsoft.Extensions.DependencyInjection;

namespace AdventureWorks.Services;

public partial interface IAdventureWorksServices 
{
    Task<CustomerModel?> FindCustomerAsync(int productCategoryId);
    IQueryable<CustomerModel> QueryCustomers();
}
internal partial class AdventureWorksServices : IAdventureWorksServices
{
    public Task<CustomerModel?> FindCustomerAsync(int productCategoryId) 
    {
        return serviceProvider
            .GetRequiredService<IFindCustomer>()
            .ExecuteAsync(productCategoryId);
    }
    public IQueryable<CustomerModel> QueryCustomers() 
    {
        return serviceProvider
            .GetRequiredService<IQueryCustomers>()
            .Execute();
    }
}
