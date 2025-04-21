using Microsoft.Extensions.DependencyInjection;

namespace AdventureWorks.Services;
public interface IAdventureWorksCommandProvider
{
    TCommand Get<TCommand>() where TCommand : ICommand;
}
internal class AdventureWorksCommandProvider(IServiceProvider serviceProvider) : IAdventureWorksCommandProvider
{
    public TCommand Get<TCommand>() where TCommand : ICommand
    {
        return serviceProvider.GetRequiredService<TCommand>();
    }
}