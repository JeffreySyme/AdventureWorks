using AdventureWorks.Data;
using AdventureWorks.Models;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.Services.ProductModels;

internal class FindProductModel(AdventureWorksDbContext db) : ICommand<int, ProductModelModel?>
{
    public Task<ProductModelModel?> ExecuteAsync(int productModelId)
    {
        return db.ProductModels
            .ProjectToModel()
            .FirstOrDefaultAsync(x => x.ProductModelId == productModelId);
    }
}
