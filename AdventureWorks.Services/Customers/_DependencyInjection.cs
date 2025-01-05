using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace AdventureWorks.Services.Customers;

[ExcludeFromCodeCoverage]
internal static class DependencyInjection
{
    public static IServiceCollection AddCustomers(this IServiceCollection services) 
    {
        services.AddScoped<FindCustomer>();
        services.AddScoped<QueryCustomers>();

        return services;
    }
}
