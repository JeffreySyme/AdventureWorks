using AdventureWorks.Models;
using AdventureWorks.Services.Functions;
using Microsoft.Extensions.DependencyInjection;

namespace AdventureWorks.Services;
public partial interface IAdventureWorksServices 
{
    Task<GetProductsResult> GetProductsAsync(GetProductsParams parameters);
}
internal partial class AdventureWorksServices : IAdventureWorksServices
{
    public Task<GetProductsResult> GetProductsAsync(GetProductsParams parameters) 
    {
        return serviceProvider
            .GetRequiredService<IGetProducts>()
            .ExecuteAsync(parameters);
    }
}