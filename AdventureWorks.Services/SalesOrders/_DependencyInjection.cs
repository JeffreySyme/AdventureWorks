using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace AdventureWorks.Services.SalesOrders;

[ExcludeFromCodeCoverage]
internal static class DependencyInjection
{
    public static IServiceCollection AddSalesOrders(this IServiceCollection services) 
    {
        services.AddScoped<IFindSalesOrder, FindSalesOrder>();
        services.AddScoped<IQuerySalesOrders, QuerySalesOrders>();

        return services;
    }
}
