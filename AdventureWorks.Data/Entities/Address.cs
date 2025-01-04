using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdventureWorks.Data.Entities;
public class Address
{
    public int AddressId { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string City { get; set; }
    public string StateProvince { get; set; }
    public string CountryRegion { get; set; }
    public string PostalCode { get; set; }
    public DateTime ModifiedDate { get; set; }
    public ICollection<CustomerAddress> CustomerAddresses { get; set; } = [];
}
internal class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("Address", "SalesLT");
        builder.HasKey(x => x.AddressId);
        builder.Property(x => x.AddressId).HasColumnName("AddressID");
        builder.Property(x => x.AddressLine1).IsRequired().HasMaxLength(60);
        builder.Property(x => x.AddressLine2).HasMaxLength(60);
        builder.Property(x => x.City).IsRequired().HasMaxLength(30);
        builder.Property(x => x.StateProvince).IsRequired();
        builder.Property(x => x.CountryRegion).IsRequired();
        builder.Property(x => x.PostalCode).IsRequired().HasMaxLength(15);
        builder.Property(x => x.ModifiedDate);
    }
}
