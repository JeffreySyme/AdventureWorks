using AdventureWorks.Data;
using AdventureWorks.Models;

namespace AdventureWorks.Services.ProductCategories;
internal interface IQueryProductCategories : IQuery<ProductCategoryModel> { }
internal class QueryProductCategories(AdventureWorksDbContext db) : IQueryProductCategories
{
    public IQueryable<ProductCategoryModel> Execute()
    {
        return db.ProductCategories.ProjectToModel();
    }
}