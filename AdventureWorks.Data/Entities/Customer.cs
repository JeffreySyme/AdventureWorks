using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdventureWorks.Data.Entities;
public class Customer
{
    public int CustomerId { get; set; }
    public bool NameStyle { get; set; }
    public string Title { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string Suffix { get; set; }
    public string CompanyName { get; set; }
    public string SalesPerson { get; set; }
    public string EmailAddress { get; set; }
    public string Phone { get; set; }
    public string PasswordHash { get; set; }
    public string PasswordSalt { get; set; }
    public DateTime ModifiedDate { get; set; }
    public ICollection<CustomerAddress> CustomerAddresses { get; set; } = [];
}
internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customer", "SalesLT");
        builder.HasKey(x => x.CustomerId);
        builder.Property(x => x.CustomerId).HasColumnName("CustomerID");
        builder.Property(x => x.NameStyle);
        builder.Property(x => x.Title).HasMaxLength(8);
        builder.Property(x => x.FirstName).IsRequired();
        builder.Property(x => x.MiddleName);
        builder.Property(x => x.LastName).IsRequired();
        builder.Property(x => x.Suffix).HasMaxLength(10);
        builder.Property(x => x.CompanyName).HasMaxLength(128);
        builder.Property(x => x.SalesPerson).HasMaxLength(256);
        builder.Property(x => x.EmailAddress).HasMaxLength(50);
        builder.Property(x => x.Phone);
        builder.Property(x => x.PasswordHash).IsRequired().HasMaxLength(128);
        builder.Property(x => x.PasswordSalt).IsRequired().HasMaxLength(10);
        builder.Property(x => x.ModifiedDate);
    }
}
