using AdventureWorks.Data;
using AdventureWorks.Models;

namespace AdventureWorks.Services.Products;
internal interface IQueryProducts : IQuery<ProductModel> { }
internal class QueryProducts(AdventureWorksDbContext db) : IQueryProducts
{
    public IQueryable<ProductModel> Execute()
    {
        return db.Products.ProjectToModel();
    }
}
