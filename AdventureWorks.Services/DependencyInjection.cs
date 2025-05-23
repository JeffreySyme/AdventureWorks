﻿using AdventureWorks.Data;
using AdventureWorks.Services.Customers;
using AdventureWorks.Services.Functions;
using AdventureWorks.Services.ProductCategories;
using AdventureWorks.Services.ProductModels;
using AdventureWorks.Services.Products;
using AdventureWorks.Services.SalesOrders;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace AdventureWorks.Services;

[ExcludeFromCodeCoverage]
public static class DependencyInjection
{
    public static IServiceCollection AddAdventureWorksServices(this IServiceCollection services, Action<AdventureWorksServicesConfiguration> configAction) 
    {
        services.AddCustomers();
        services.AddFunctions();
        services.AddProductCategories();
        services.AddProductModels();
        services.AddProducts();
        services.AddSalesOrders();

        services.AddScoped<IAdventureWorksValidator, AdventureWorksValidator>();
        services.AddScoped<IAdventureWorksCommandProvider, AdventureWorksCommandProvider>();

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
