using AdventureWorks.Models;
using AdventureWorks.Services.Customers;
using AdventureWorks.Services.ProductCategories;
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
            .GetRequiredService<FindCustomer>()
            .ExecuteAsync(productCategoryId);
    }
    public IQueryable<CustomerModel> QueryCustomers() 
    {
        return serviceProvider
            .GetRequiredService<QueryCustomers>()
            .Execute();
    }
}
