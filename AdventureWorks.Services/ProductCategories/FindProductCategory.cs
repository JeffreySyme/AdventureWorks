using AdventureWorks.Data;
using AdventureWorks.Models;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.Services.ProductCategories;
internal class FindProductCategory(AdventureWorksDbContext db) : ICommand<int, ProductCategoryModel?>
{
    public Task<ProductCategoryModel?> ExecuteAsync(int productCategoryId)
    {
        return db.ProductCategories
            .ProjectToModel()
            .FirstOrDefaultAsync(x => x.ProductCategoryId == productCategoryId);
    }
}
