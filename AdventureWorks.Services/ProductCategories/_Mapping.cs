using AdventureWorks.Data.Entities;
using AdventureWorks.Models;

namespace AdventureWorks.Services.ProductCategories;
internal static class Mapping
{
    public static IQueryable<ProductCategoryModel> ProjectToModel(this IQueryable<ProductCategory> entities) 
    {
        return entities.Select(e => new ProductCategoryModel
        {
            ProductCategoryId = e.ProductCategoryId,
            ParentProductCategoryId = e.ParentProductCategoryId,
            Name = e.Name,
            ModifiedDate = e.ModifiedDate,
        });
    }

    public static void MapToEntity(this ProductCategoryModel model, ProductCategory entity) 
    {
        entity.ParentProductCategoryId = model.ParentProductCategoryId;
        entity.Name = model.Name;
        entity.ModifiedDate = DateTime.Now;
    }
}