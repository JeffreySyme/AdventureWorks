using AdventureWorks.Data;
using AdventureWorks.Models;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.Services.ProductCategories;
public interface IUpdateProductCategory : ICommand<ProductCategoryModel, ProductCategoryModel> { }
internal class UpdateProductCategory(AdventureWorksDbContext db) : IUpdateProductCategory
{
    public async Task<ProductCategoryModel> ExecuteAsync(ProductCategoryModel model)
    {
        var entity = await db.ProductCategories
            .FirstAsync(x => x.ProductCategoryId == model.ProductCategoryId);

        model.MapToEntity(entity);

        await db.SaveChangesAsync();

        return model;
    }
}
