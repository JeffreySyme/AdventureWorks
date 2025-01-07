using AdventureWorks.Data;
using AdventureWorks.Models;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.Services.Products;
internal class CreateProduct(AdventureWorksDbContext db) : ICommand<ProductModel, ProductModel>
{
    public async Task<ProductModel> ExecuteAsync(ProductModel model)
    {
        var entity = new Data.Entities.Product();

        model.MapToEntity(entity);

        db.Products.Add(entity);

        await db.SaveChangesAsync();

        return await db.Products
            .ProjectToModel()
            .FirstAsync(x => x.ProductId == entity.ProductId);
    }
}