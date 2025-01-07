using AdventureWorks.Data;
using AdventureWorks.Models;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.Services.Products;
internal class UpdateProduct(AdventureWorksDbContext db) : ICommand<ProductModel, ProductModel>
{
    public async Task<ProductModel> ExecuteAsync(ProductModel model)
    {
        var entity = await db.Products.FirstAsync(x => x.ProductId == model.ProductId);

        model.MapToEntity(entity);

        await db.SaveChangesAsync();

        return model;
    }
}
