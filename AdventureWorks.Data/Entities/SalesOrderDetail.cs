using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace AdventureWorks.Data.Entities;

[ExcludeFromCodeCoverage]
public class SalesOrderDetail
{
    public int SalesOrderId { get; set; }
    public SalesOrderHeader SalesOrderHeader { get; set; }
    public int SalesOrderDetailId { get; set; }
    public byte OrderQty { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal UnitPriceDiscount { get; set; }
    public decimal LineTotal { get; set; }
    public DateTime ModifiedDate { get; set; }
}

[ExcludeFromCodeCoverage]
internal class SalesOrderDetailConfiguration : IEntityTypeConfiguration<SalesOrderDetail>
{
    public void Configure(EntityTypeBuilder<SalesOrderDetail> builder)
    {
        builder.HasKey(x => new { x.SalesOrderId, x.SalesOrderDetailId });
        builder.Property(x => x.SalesOrderId).HasColumnName("SalesOrderID");
        builder.Property(x => x.SalesOrderDetailId).HasColumnName("SalesOrderDetailID");
        builder.Property(x => x.OrderQty);
        builder.Property(x => x.ProductId).HasColumnName("ProductID");
        builder.Property(x => x.UnitPrice);
        builder.Property(x => x.UnitPriceDiscount);
        builder.Property(x => x.LineTotal);
        builder.Property(x => x.ModifiedDate);

        builder.HasOne(x => x.SalesOrderHeader)
            .WithMany(x => x.SalesOrderDetails)
            .HasForeignKey(x => x.SalesOrderId);

        builder.HasOne(x => x.Product)
            .WithMany(x => x.SalesOrderDetails)
            .HasForeignKey(x => x.ProductId);
    }
}