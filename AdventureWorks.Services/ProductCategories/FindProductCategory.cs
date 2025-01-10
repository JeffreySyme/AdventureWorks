using AdventureWorks.Data;
using AdventureWorks.Models;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.Services.ProductCategories;
internal interface IFindProductCategory : ICommand<int, ProductCategoryModel?> { }
internal class FindProductCategory(AdventureWorksDbContext db) : IFindProductCategory
{
    public Task<ProductCategoryModel?> ExecuteAsync(int productCategoryId)
    {
        return db.ProductCategories
            .ProjectToModel()
            .FirstOrDefaultAsync(x => x.ProductCategoryId == productCategoryId);
    }
}
