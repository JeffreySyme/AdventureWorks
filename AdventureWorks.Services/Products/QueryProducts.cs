using AdventureWorks.Data;
using AdventureWorks.Models;

namespace AdventureWorks.Services.Products;

internal class QueryProducts(AdventureWorksDbContext db) : IQuery<ProductModel>
{
    public IQueryable<ProductModel> Execute()
    {
        return db.Products.ProjectToModel();
    }
}
