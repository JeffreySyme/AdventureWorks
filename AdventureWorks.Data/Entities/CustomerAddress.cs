using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace AdventureWorks.Data.Entities;

[ExcludeFromCodeCoverage]
public class CustomerAddress
{
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public int AddressId { get; set; }
    public Address Address { get; set; }
    public string AddressType { get; set; }
    public DateTime ModifiedDate { get; set; }
}

[ExcludeFromCodeCoverage]
internal class CustomerAddressConfiguration : IEntityTypeConfiguration<CustomerAddress>
{
    public void Configure(EntityTypeBuilder<CustomerAddress> builder)
    {
        builder.ToTable("CustomerAddress", "SalesLT");
        builder.HasKey(x => new { x.CustomerId, x.AddressId });
        builder.Property(x => x.CustomerId).HasColumnName("CustomerID");
        builder.Property(x => x.AddressId).HasColumnName("AddressID");
        builder.Property(x => x.AddressType).IsRequired();
        builder.Property(x => x.ModifiedDate);
    }
}