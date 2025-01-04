using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdventureWorks.Data.Entities;
public class ProductCategory
{
    public int ProductCategoryId { get; set; }
    public int? ParentProductCategoryId { get; set; }
    public ProductCategory ParentProductCategory { get; set; }
    public string Name { get; set; }
    public DateTime ModifiedDate { get; set; }
    public ICollection<Product> Products { get; set; } = [];
    public ICollection<ProductCategory> ChildCategories { get; set; } = [];
}
internal class ProductCategoriesConfiguration : IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.ToTable("ProductCategory", "SalesLT");
        builder.HasKey(x => x.ProductCategoryId);
        builder.Property(x => x.ProductCategoryId).HasColumnName("ProductCategoryID");
        builder.Property(x => x.ParentProductCategoryId).HasColumnName("ParentProductCategoryID");
        builder.Property(x => x.Name);
        builder.Property(x => x.ModifiedDate);

        builder.HasOne(x => x.ParentProductCategory)
            .WithMany(x => x.ChildCategories)
            .HasForeignKey(x => x.ParentProductCategoryId);
    }
}