using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace AdventureWorks.Data;

[ExcludeFromCodeCoverage]
public static class DependencyInjection
{
    public static IServiceCollection AddAdventureWorksDbContext(this IServiceCollection services, string connectionString) 
    {
        return services.AddDbContext<AdventureWorksDbContext>(
            config => config.UseSqlServer(connectionString,
            opts => opts.TranslateParameterizedCollectionsToConstants()));
    }
}
