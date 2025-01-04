using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdventureWorks.Data.Entities;
public class ProductDescription
{
    public int ProductDescriptionId { get; set; }
    public string Description { get; set; }
    public DateTime ModifiedDate { get; set; }
}
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