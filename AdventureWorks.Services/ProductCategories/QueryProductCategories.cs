using AdventureWorks.Data;
using AdventureWorks.Models;

namespace AdventureWorks.Services.ProductCategories;
internal class QueryProductCategories(AdventureWorksDbContext db) : IQuery<ProductCategoryModel>
{
    public IQueryable<ProductCategoryModel> Execute()
    {
        return db.ProductCategories.ProjectToModel();
    }
}