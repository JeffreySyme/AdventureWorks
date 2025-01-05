using AdventureWorks.Models;
using AdventureWorks.Services.ProductCategories;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace AdventureWorks.Services;

public partial interface IAdventureWorksServices 
{
    Task<ProductCategoryModel?> FindProductCategory(int productCategoryId);
    IQueryable<ProductCategoryModel> QueryProductCategories();
}

[ExcludeFromCodeCoverage]
internal partial class AdventureWorksServices(IServiceProvider serviceProvider) : IAdventureWorksServices
{
    public Task<ProductCategoryModel?> FindProductCategory(int productCategoryId) 
    {
        return serviceProvider
            .GetRequiredService<FindProductCategory>()
            .ExecuteAsync(productCategoryId);
    }
    public IQueryable<ProductCategoryModel> QueryProductCategories() 
    {
        return serviceProvider
            .GetRequiredService<QueryProductCategories>()
            .Execute();
    }
}
