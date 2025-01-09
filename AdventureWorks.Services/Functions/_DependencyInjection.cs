using Microsoft.Extensions.DependencyInjection;

namespace AdventureWorks.Services.Functions;

internal static class DependencyInjection
{
    public static IServiceCollection AddFunctions(this IServiceCollection services) 
    {
        services.AddScoped<GetProducts>();

        return services;
    }
}
