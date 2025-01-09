using AdventureWorks.Data;
using AdventureWorks.Models;
using AdventureWorks.Services.ProductModels;
using AdventureWorks.Services.Products;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.Services.Functions;
internal class GetProducts(AdventureWorksDbContext db) : ICommand<GetProductsParams, GetProductsResult>
{
    public async Task<GetProductsResult> ExecuteAsync(GetProductsParams parameters)
    {
        var products = await db.Products
            .Where(p => parameters.ProductIds.Contains(p.ProductId))
            .ProjectToModel()
            .ToListAsync();

        var productModels = await db.ProductModels
            .Where(pm => products.Select(p => p.ProductModelId).Contains(pm.ProductModelId))
            .ProjectToModel()
            .ToListAsync();

        return new GetProductsResult
        {
            Products = products,
            ProductModels = productModels,
        };
    }
}