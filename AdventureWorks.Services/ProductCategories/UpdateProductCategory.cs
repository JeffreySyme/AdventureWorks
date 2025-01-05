using AdventureWorks.Data;
using AdventureWorks.Models;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.Services.ProductCategories;

internal class UpdateProductCategory(AdventureWorksDbContext db) : ICommand<ProductCategoryModel, ProductCategoryModel>
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
