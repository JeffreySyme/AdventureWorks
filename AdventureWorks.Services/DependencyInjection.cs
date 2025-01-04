using AdventureWorks.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AdventureWorks.Services.DependencyInjection;
public static class DependencyInjection
{
    public static IServiceCollection AddAdventureWorksServices(this IServiceCollection services, Action<AdventureWorksServicesConfiguration> configAction) 
    {


        configAction.Invoke(new AdventureWorksServicesConfiguration(services));

        return services;
    }
}
public class AdventureWorksServicesConfiguration(IServiceCollection services)
{
    public void AddAdventureWorksDb(string connectionString) 
    {
        services.AddAdventureWorksDbContext(connectionString);
    }
}
