using AdventureWorks.Models;
using AdventureWorks.Services.ProductModels;
using Microsoft.Extensions.DependencyInjection;

namespace AdventureWorks.Services;
public partial interface IAdventureWorksServices 
{
    Task<ProductModelModel?> FindProductModelAsync(int productModelId);
    IQueryable<ProductModelModel> QueryProductModels();
}
internal partial class AdventureWorksServices : IAdventureWorksServices
{
    public Task<ProductModelModel?> FindProductModelAsync(int productModelId) 
    {
        return serviceProvider
            .GetRequiredService<IFindProductModel>()
            .ExecuteAsync(productModelId);
    }
    public IQueryable<ProductModelModel> QueryProductModels() 
    {
        return serviceProvider
            .GetRequiredService<IQueryProductModels>()
            .Execute();
    }
}
