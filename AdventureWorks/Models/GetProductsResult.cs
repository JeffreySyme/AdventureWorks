namespace AdventureWorks.Models;
public class GetProductsResult
{
    public IEnumerable<ProductModel> Products { get; set; } = [];
    public IEnumerable<ProductModelModel> ProductModels { get; set; } = [];
}