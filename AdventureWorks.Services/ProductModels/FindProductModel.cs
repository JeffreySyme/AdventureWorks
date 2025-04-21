using AdventureWorks.Data;
using AdventureWorks.Models;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.Services.ProductModels;
public interface IFindProductModel : ICommand<int, ProductModelModel?> { }
internal class FindProductModel(AdventureWorksDbContext db) : IFindProductModel
{
    public Task<ProductModelModel?> ExecuteAsync(int productModelId)
    {
        return db.ProductModels
            .ProjectToModel()
            .FirstOrDefaultAsync(x => x.ProductModelId == productModelId);
    }
}
