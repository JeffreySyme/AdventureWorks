using AdventureWorks.Models;

namespace AdventureWorks.Services.Products;

internal static class Mapping
{
    public static IQueryable<ProductModel> ProjectToModel(this IQueryable<Data.Entities.Product> entities) 
    {
        return entities.Select(e => new ProductModel
        {
            ProductId = e.ProductId,
            Name = e.Name,
            ProductNumber = e.ProductNumber,
            Color = e.Color,
            StandardCost = e.StandardCost,
            ListPrice = e.ListPrice,
            Size = e.Size,
            Weight = e.Weight,
            ProductCategoryId = e.ProductCategoryId,
            ProductModelId = e.ProductModelId,
            SellStartDate = e.SellStartDate,
            SellEndDate = e.SellEndDate,
            DiscontinuedDate = e.DiscontinuedDate,
            ModifiedDate = e.ModifiedDate,
        });
    }
    public static void MapToEntity(this ProductModel model, Data.Entities.Product entity) 
    {
        entity.Name = model.Name;
        entity.ProductNumber = model.ProductNumber;
        entity.Color = model.Color;
        entity.StandardCost = model.StandardCost;
        entity.ListPrice = model.ListPrice;
        entity.Size = model.Size;
        entity.Weight = model.Weight;
        entity.ProductCategoryId = model.ProductCategoryId;
        entity.ProductModelId = model.ProductModelId;
        entity.SellStartDate = model.SellStartDate;
        entity.SellEndDate = model.SellEndDate;
        entity.DiscontinuedDate = model.DiscontinuedDate;
        entity.ModifiedDate = DateTime.Now;
    }
}
