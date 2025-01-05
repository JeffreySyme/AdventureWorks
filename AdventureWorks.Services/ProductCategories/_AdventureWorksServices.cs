﻿using AdventureWorks.Models;
using AdventureWorks.Services.ProductCategories;
using Microsoft.Extensions.DependencyInjection;

namespace AdventureWorks.Services;

public partial interface IAdventureWorksServices 
{
    Task<ProductCategoryModel?> FindProductCategoryAsync(int productCategoryId);
    IQueryable<ProductCategoryModel> QueryProductCategories();
}
internal partial class AdventureWorksServices : IAdventureWorksServices
{
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
}
