﻿using AdventureWorks.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace AdventureWorks.Data;

[ExcludeFromCodeCoverage]
public class AdventureWorksDbContext(DbContextOptions<AdventureWorksDbContext> options) : DbContext(options)
{
    public DbSet<Address> Addresses { get; set; }
    public DbSet<CustomerAddress> CustomerAddresses { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<ProductDescription> ProductDescriptions { get; set; }
    public DbSet<ProductModel> ProductModels { get; set; }
    public DbSet<ProductModelProductDescription> ProductModelProductDescriptions { get; set; }
    public DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }
    public DbSet<SalesOrderHeader> SalesOrderHeaders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AddressConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerAddressConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new ProductCategoriesConfiguration());
        modelBuilder.ApplyConfiguration(new ProductDescriptionConfiguration());
        modelBuilder.ApplyConfiguration(new ProductModelConfiguration());
        modelBuilder.ApplyConfiguration(new ProductModelProductDescriptionConfiguration());
        modelBuilder.ApplyConfiguration(new SalesOrderDetailConfiguration());
        modelBuilder.ApplyConfiguration(new SalesOrderHeaderConfiguration());
    }
}