namespace AdventureWorks.Services;

public interface ICommand { }
public interface ICommand<TParam, TResult> : ICommand
{
    Task<TResult> ExecuteAsync(TParam parameters);
}
public interface IQuery<TResult> : ICommand
{
    IQueryable<TResult> Execute();
}