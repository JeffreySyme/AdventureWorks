using AdventureWorks.Models;
using AdventureWorks.Services.Products;
using Microsoft.Extensions.DependencyInjection;

namespace AdventureWorks.Services;
public partial interface IAdventureWorksServices 
{
    Task<ProductModel> CreateProductAsync(ProductModel model);
    Task<ProductModel?> FindProductAsync(int productId);
    IQueryable<ProductModel> QueryProducts();
    Task<ProductModel> UpdateProductAsync(ProductModel model);
}
internal partial class AdventureWorksServices : IAdventureWorksServices
{
    public Task<ProductModel> CreateProductAsync(ProductModel model) 
    {
        return serviceProvider
            .GetRequiredService<ICreateProduct>()
            .ExecuteAsync(model);
    }
    public Task<ProductModel?> FindProductAsync(int productId) 
    {
        return serviceProvider
            .GetRequiredService<IFindProduct>()
            .ExecuteAsync(productId);
    }
    public IQueryable<ProductModel> QueryProducts() 
    {
        return serviceProvider
            .GetRequiredService<IQueryProducts>()
            .Execute();
    }
    public Task<ProductModel> UpdateProductAsync(ProductModel model) 
    {
        return serviceProvider
            .GetRequiredService<IUpdateProduct>()
            .ExecuteAsync(model);
    }
}
