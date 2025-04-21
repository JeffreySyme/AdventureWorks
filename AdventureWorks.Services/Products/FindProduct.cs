using AdventureWorks.Data;
using AdventureWorks.Models;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.Services.Products;
public interface IFindProduct : ICommand<int, ProductModel?> { }
internal class FindProduct(AdventureWorksDbContext db) : IFindProduct
{
    public Task<ProductModel?> ExecuteAsync(int productId)
    {
        return db.Products
            .ProjectToModel()
            .FirstOrDefaultAsync(x => x.ProductId == productId);
    }
}
