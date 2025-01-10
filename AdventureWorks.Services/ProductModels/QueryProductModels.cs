using AdventureWorks.Data;
using AdventureWorks.Models;

namespace AdventureWorks.Services.ProductModels;
internal interface IQueryProductModels : IQuery<ProductModelModel> { } 
internal class QueryProductModels(AdventureWorksDbContext db) : IQueryProductModels
{
    public IQueryable<ProductModelModel> Execute()
    {
        return db.ProductModels.ProjectToModel();
    }
}
