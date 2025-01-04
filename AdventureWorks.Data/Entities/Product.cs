using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdventureWorks.Data.Entities;
public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string ProductNumber { get; set; }
    public string Color { get; set; }
    public decimal StandardCost { get; set; }
    public decimal ListPrice { get; set; }
    public string Size { get; set; }
    public decimal? Weight { get; set; }
    public int ProductCategoryId { get; set; }
    public ProductCategory ProductCategory { get; set; }
    public int ProductModelId { get; set; }
    public ProductModel ProductModel { get; set; }
    public DateTime SellStartDate { get; set; }
    public DateTime? SellEndDate { get; set; }
    public DateTime? DiscontinuedDate { get; set; }
    public byte[] ThumbnailPhoto { get; set; }
    public string ThumbnailPhotoFileName { get; set; }
    public DateTime ModifiedDate { get; set; }
}
internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Product", "SalesLT");
        builder.HasKey(x => x.ProductId);
        builder.Property(x => x.ProductId).HasColumnName("ProductID");
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.ProductNumber).IsRequired().HasMaxLength(25);
        builder.Property(x => x.Color).HasMaxLength(15);
        builder.Property(x => x.StandardCost);
        builder.Property(x => x.ListPrice);
        builder.Property(x => x.Size).HasMaxLength(5);
        builder.Property(x => x.Weight).HasPrecision(8,2);
        builder.Property(x => x.ProductCategoryId).HasColumnName("ProductCategoryID");
        builder.Property(x => x.ProductModelId).HasColumnName("ProductModelID");
        builder.Property(x => x.SellStartDate);
        builder.Property(x => x.SellEndDate);
        builder.Property(x => x.DiscontinuedDate);
        builder.Property(x => x.ThumbnailPhoto);
        builder.Property(x => x.ThumbnailPhotoFileName).HasMaxLength(50);
        builder.Property(x => x.ModifiedDate);

        builder.HasOne(x => x.ProductCategory)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.ProductCategoryId);

        builder.HasOne(x => x.ProductModel)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.ProductModelId);
    }
}
