using AdventureWorks.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.Data;
public class AdventureWorksDbContext(DbContextOptions<AdventureWorksDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductCategoriesConfiguration());
    }
}