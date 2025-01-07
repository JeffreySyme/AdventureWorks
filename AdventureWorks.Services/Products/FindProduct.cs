using AdventureWorks.Data;
using AdventureWorks.Models;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.Services.Products;

internal class FindProduct(AdventureWorksDbContext db) : ICommand<int, ProductModel?>
{
    public Task<ProductModel?> ExecuteAsync(int productId)
    {
        return db.Products
            .ProjectToModel()
            .FirstOrDefaultAsync(x => x.ProductId == productId);
    }
}
