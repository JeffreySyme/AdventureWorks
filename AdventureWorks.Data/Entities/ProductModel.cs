using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace AdventureWorks.Data.Entities;

[ExcludeFromCodeCoverage]
public class ProductModel
{
    public int ProductModelId { get; set; }
    public string Name { get; set; }
    public DateTime ModifiedDate { get; set; }
    public ICollection<Product> Products { get; set; } = [];
    public ICollection<ProductModelProductDescription> ProductModelProductDescriptions { get; set; } = [];
}

[ExcludeFromCodeCoverage]
internal class ProductModelConfiguration : IEntityTypeConfiguration<ProductModel>
{
    public void Configure(EntityTypeBuilder<ProductModel> builder)
    {
        builder.ToTable("ProductModel", "SalesLT");
        builder.HasKey(x => x.ProductModelId);
        builder.Property(x => x.ProductModelId).HasColumnName("ProductModelID");
        builder.Property(x => x.ModifiedDate);
    }
}