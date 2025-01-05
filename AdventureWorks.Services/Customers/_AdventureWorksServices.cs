using AdventureWorks.Models;
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
    public Task<ProductCategoryModel?> FindCustomerAsync(int productCategoryId) 
    {
        return serviceProvider
            .GetRequiredService<FindProductCategory>()
            .ExecuteAsync(productCategoryId);
    }
    public IQueryable<ProductCategoryModel> QueryCustomers() 
    {
        return serviceProvider
            .GetRequiredService<QueryProductCategories>()
            .Execute();
    }
}
