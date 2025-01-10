using AdventureWorks.Data;
using AdventureWorks.Models;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.Services.Products;
internal interface IUpdateProduct : ICommand<ProductModel, ProductModel> { }
internal class UpdateProduct(AdventureWorksDbContext db) : IUpdateProduct
{
    public async Task<ProductModel> ExecuteAsync(ProductModel model)
    {
        var entity = await db.Products.FirstAsync(x => x.ProductId == model.ProductId);

        model.MapToEntity(entity);

        await db.SaveChangesAsync();

        return model;
    }
}
