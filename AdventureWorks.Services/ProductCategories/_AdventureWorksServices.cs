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
            .GetRequiredService<ICreateProductCategory>()
            .ExecuteAsync(model);
    }

    public Task<ProductCategoryModel?> FindProductCategoryAsync(int productCategoryId) 
    {
        return serviceProvider
            .GetRequiredService<IFindProductCategory>()
            .ExecuteAsync(productCategoryId);
    }

    public IQueryable<ProductCategoryModel> QueryProductCategories() 
    {
        return serviceProvider
            .GetRequiredService<IQueryProductCategories>()
            .Execute();
    }

    public Task<ProductCategoryModel> UpdateProductCategoryAsync(ProductCategoryModel model) 
    {
        return serviceProvider
            .GetRequiredService<IUpdateProductCategory>()
            .ExecuteAsync(model);
    }
}
