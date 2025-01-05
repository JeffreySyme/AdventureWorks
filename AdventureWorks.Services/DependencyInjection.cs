using AdventureWorks.Data;
using AdventureWorks.Services.Customers;
using AdventureWorks.Services.ProductCategories;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace AdventureWorks.Services.DependencyInjection;

[ExcludeFromCodeCoverage]
public static class DependencyInjection
{
    public static IServiceCollection AddAdventureWorksServices(this IServiceCollection services, Action<AdventureWorksServicesConfiguration> configAction) 
    {
        services.AddCustomers();
        services.AddProductCategories();

        configAction.Invoke(new AdventureWorksServicesConfiguration(services));

        return services;
    }
}

[ExcludeFromCodeCoverage]
public class AdventureWorksServicesConfiguration(IServiceCollection services)
{
    public void AddAdventureWorksDb(string connectionString) 
    {
        services.AddAdventureWorksDbContext(connectionString);
    }
}
