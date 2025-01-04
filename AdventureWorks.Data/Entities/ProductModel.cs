using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdventureWorks.Data.Entities;
public class ProductModel
{
    public int ProductModelId { get; set; }
    public string Name { get; set; }
    public DateTime ModifiedDate { get; set; }
}
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