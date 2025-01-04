using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AdventureWorks.Data;
public static class DependencyInjection
{
    public static IServiceCollection AddAdventureWorksDbContext(this IServiceCollection services, string connectionString) 
    {
        return services.AddDbContext<AdventureWorksDbContext>(config => config.UseSqlServer(connectionString));
    }
}
