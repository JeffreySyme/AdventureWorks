using AdventureWorks.Data;
using AdventureWorks.Models;

namespace AdventureWorks.Services.ProductModels;

internal class QueryProductModels(AdventureWorksDbContext db) : IQuery<ProductModelModel>
{
    public IQueryable<ProductModelModel> Execute()
    {
        return db.ProductModels.ProjectToModel();
    }
}
