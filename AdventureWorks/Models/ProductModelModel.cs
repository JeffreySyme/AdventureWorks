using System.Diagnostics.CodeAnalysis;

namespace AdventureWorks.Models;

[ExcludeFromCodeCoverage]
public class ProductModelModel
{
    public int ProductModelId { get; set; }
    public string Name { get; set; }
    public DateTime ModifiedDate { get; set; }
}
