using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace AdventureWorks.Data.Entities;

[ExcludeFromCodeCoverage]
public class ProductDescription
{
    public int ProductDescriptionId { get; set; }
    public string Description { get; set; }
    public DateTime ModifiedDate { get; set; }
    public ICollection<ProductModelProductDescription> ProductModelProductDescriptions { get; set; } = [];
}

[ExcludeFromCodeCoverage]
internal class ProductDescriptionConfiguration : IEntityTypeConfiguration<ProductDescription>
{
    public void Configure(EntityTypeBuilder<ProductDescription> builder)
    {
        builder.ToTable("ProductDescription", "SalesLT");
        builder.HasKey(x => x.ProductDescriptionId);
        builder.Property(x => x.ProductDescriptionId).HasColumnName("ProductDescriptionID");
        builder.Property(x => x.Description).IsRequired().HasMaxLength(400);
        builder.Property(x => x.ModifiedDate);
    }
}