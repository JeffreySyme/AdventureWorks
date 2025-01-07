using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace AdventureWorks.Services.SalesOrders;

[ExcludeFromCodeCoverage]
internal static class DependencyInjection
{
    public static IServiceCollection AddSalesOrders(this IServiceCollection services) 
    {
        services.AddScoped<FindSalesOrder>();
        services.AddScoped<QuerySalesOrders>();

        return services;
    }
}
