using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace AdventureWorks.Services;
public interface IAdventureWorksCommandProvider
{
    TCommand Get<TCommand>() where TCommand : ICommand;
}

[ExcludeFromCodeCoverage]
internal class AdventureWorksCommandProvider(IServiceProvider serviceProvider) : IAdventureWorksCommandProvider
{
    public TCommand Get<TCommand>() where TCommand : ICommand
    {
        return serviceProvider.GetRequiredService<TCommand>();
    }
}