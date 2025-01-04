﻿using AdventureWorks.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.Data;
public class AdventureWorksDbContext(DbContextOptions<AdventureWorksDbContext> options) : DbContext(options)
{
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<ProductDescription> ProductDescriptions { get; set; }
    public DbSet<ProductModel> ProductModels { get; set; }
    public DbSet<ProductModelProductDescription> ProductModelProductDescriptions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductCategoriesConfiguration());
        modelBuilder.ApplyConfiguration(new ProductDescriptionConfiguration());
        modelBuilder.ApplyConfiguration(new ProductModelConfiguration());
        modelBuilder.ApplyConfiguration(new ProductModelProductDescriptionConfiguration());
    }
}