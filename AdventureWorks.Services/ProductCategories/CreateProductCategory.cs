using AdventureWorks.Data;
using AdventureWorks.Data.Entities;
using AdventureWorks.Models;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.Services.ProductCategories;
internal interface ICreateProductCategory : ICommand<ProductCategoryModel, ProductCategoryModel> { }
internal class CreateProductCategory(AdventureWorksDbContext db) : ICreateProductCategory
{
    public async Task<ProductCategoryModel> ExecuteAsync(ProductCategoryModel model)
    {
        var entity = new ProductCategory();

        model.MapToEntity(entity);

        db.ProductCategories.Add(entity);

        await db.SaveChangesAsync();

        return await db.ProductCategories
            .ProjectToModel()
            .FirstAsync(x => x.ProductCategoryId == entity.ProductCategoryId);
    }
}
