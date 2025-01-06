using AdventureWorks.Data.Entities;
using AdventureWorks.Models;
using AdventureWorks.Services.ProductCategories;
using Microsoft.Extensions.DependencyInjection;

namespace AdventureWorks.Services;

public partial interface IAdventureWorksServices 
{
    Task<ProductCategoryModel> CreateProductCategoryAsync(ProductCategoryModel model);
    Task<ProductCategoryModel?> FindProductCategoryAsync(int productCategoryId);
    IQueryable<ProductCategoryModel> QueryProductCategories();
    Task<ProductCategoryModel> UpdateProductCategoryAsync(ProductCategoryModel model);
}
internal partial class AdventureWorksServices : IAdventureWorksServices
{
    public Task<ProductCategoryModel> CreateProductCategoryAsync(ProductCategoryModel model) 
    {
        return serviceProvider
            .GetRequiredService<CreateProductCategory>()
            .ExecuteAsync(model);
    }

    public Task<ProductCategoryModel?> FindProductCategoryAsync(int productCategoryId) 
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

    public Task<ProductCategoryModel> UpdateProductCategoryAsync(ProductCategoryModel model) 
    {
        return serviceProvider
            .GetRequiredService<UpdateProductCategory>()
            .ExecuteAsync(model);
    }
}
