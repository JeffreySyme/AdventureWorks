using Microsoft.Extensions.DependencyInjection;

namespace AdventureWorks.Services;
internal interface ICommandProvider
{
    TCommand Get<TCommand>() where TCommand : ICommand;
}
internal class CommandProvider(IServiceProvider serviceProvider) : ICommandProvider
{
    public TCommand Get<TCommand>() where TCommand : ICommand
    {
        return serviceProvider.GetRequiredService<TCommand>();
    }
}