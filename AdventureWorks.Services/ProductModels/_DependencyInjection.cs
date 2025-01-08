using Microsoft.Extensions.DependencyInjection;

namespace AdventureWorks.Services.ProductModels;

internal static class DependencyInjection
{
    public static IServiceCollection AddProductModels(this IServiceCollection services) 
    {
        services.AddScoped<QueryProductModels>();

        return services;
    }
}
