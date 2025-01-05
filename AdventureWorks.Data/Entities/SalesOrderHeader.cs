using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace AdventureWorks.Data.Entities;

[ExcludeFromCodeCoverage]
public class SalesOrderHeader
{
    public int SalesOrderId { get; set; }
    public byte RevisionNumber { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ShipDate { get; set; }
    public byte Status { get; set; }
    public bool OnlineOrderFlag { get; set; }
    public string SalesOrderNumber { get; set; }
    public string PurchaseOrderNumber { get; set; }
    public string AccountNumber { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public int? ShipToAddressId { get; set; }
    public Address ShipToAddress { get; set; }
    public int? BillToAddressId { get; set; }
    public Address BillToAddress { get; set; }
    public string ShipMethod { get; set; }
    public string CreditCardApprovalCode { get; set; }
    public decimal SubTotal { get; set; }
    public decimal TaxAmt { get; set; }
    public decimal Freight { get; set; }
    public decimal TotalDue { get; set; }
    public string Comment { get; set; }
    public DateTime ModifiedDate { get; set; }
    public ICollection<SalesOrderDetail> SalesOrderDetails { get; set; } = [];
}

[ExcludeFromCodeCoverage]
internal class SalesOrderHeaderConfiguration : IEntityTypeConfiguration<SalesOrderHeader>
{
    public void Configure(EntityTypeBuilder<SalesOrderHeader> builder)
    {
        builder.ToTable("SalesOrderHeader", "SalesLT");
        builder.HasKey(x => x.SalesOrderId);
        builder.Property(x => x.SalesOrderId).HasColumnName("SalesOrderID");
        builder.Property(x => x.RevisionNumber);
        builder.Property(x => x.OrderDate);
        builder.Property(x => x.DueDate);
        builder.Property(x => x.ShipDate);
        builder.Property(x => x.Status);
        builder.Property(x => x.OnlineOrderFlag);
        builder.Property(x => x.SalesOrderNumber).HasComputedColumnSql();
        builder.Property(x => x.PurchaseOrderNumber);
        builder.Property(x => x.AccountNumber);
        builder.Property(x => x.CustomerId).HasColumnName("CustomerID");
        builder.Property(x => x.ShipToAddressId).HasColumnName("ShipToAddressID");
        builder.Property(x => x.BillToAddressId).HasColumnName("BillToAddressID");
        builder.Property(x => x.ShipMethod).IsRequired().HasMaxLength(50);
        builder.Property(x => x.CreditCardApprovalCode).HasMaxLength(15);
        builder.Property(x => x.SubTotal);
        builder.Property(x => x.TaxAmt);
        builder.Property(x => x.Freight);
        builder.Property(x => x.TotalDue).HasComputedColumnSql();
        builder.Property(x => x.Comment);
        builder.Property(x => x.ModifiedDate);

        builder.HasOne(x => x.Customer)
            .WithMany(x => x.SalesOrderHeaders)
            .HasForeignKey(x => x.CustomerId);

        builder.HasOne(x => x.ShipToAddress)
            .WithMany(x => x.ShipToSalesOrderHeaders)
            .HasForeignKey(x => x.ShipToAddressId);

        builder.HasOne(x => x.BillToAddress)
            .WithMany(x => x.BillToSalesOrderHeaders)
            .HasForeignKey(x => x.BillToAddressId);
    }
}
