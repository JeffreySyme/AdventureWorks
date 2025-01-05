using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace AdventureWorks.Data.Entities;

[ExcludeFromCodeCoverage]
public class ProductModelProductDescription
{
    public int ProductModelId { get; set; }
    public ProductModel ProductModel { get; set; }
    public int ProductDescriptionId { get; set; }
    public ProductDescription ProductDescription { get; set; }
    public string Culture { get; set; }
    public DateTime ModifiedDate { get; set; }
}

[ExcludeFromCodeCoverage]
internal class ProductModelProductDescriptionConfiguration : IEntityTypeConfiguration<ProductModelProductDescription>
{
    public void Configure(EntityTypeBuilder<ProductModelProductDescription> builder)
    {
        builder.HasKey(x => new { x.ProductModelId, x.ProductDescriptionId, x.Culture });
        builder.Property(x => x.ProductModelId).HasColumnName("ProductModelID");
        builder.Property(x => x.ProductDescriptionId).HasColumnName("ProductDescriptionID");

        builder.HasOne(x => x.ProductModel)
            .WithMany(x => x.ProductModelProductDescriptions)
            .HasForeignKey(x => x.ProductModelId);

        builder.HasOne(x => x.ProductDescription)
            .WithMany(x => x.ProductModelProductDescriptions)
            .HasForeignKey(x => x.ProductDescriptionId);
    }
}
