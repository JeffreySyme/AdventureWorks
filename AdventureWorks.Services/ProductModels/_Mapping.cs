using AdventureWorks.Models;

namespace AdventureWorks.Services.ProductModels;

internal static class Mapping
{
    public static IQueryable<ProductModelModel> ProjectToModel(this IQueryable<Data.Entities.ProductModel> entities) 
    {
        return entities.Select(e => new ProductModelModel
        {
            ProductModelId = e.ProductModelId,
            Name = e.Name,
            ModifiedDate = e.ModifiedDate,
        });
    }
}
