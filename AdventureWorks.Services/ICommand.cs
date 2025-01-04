namespace AdventureWorks.Services;
internal interface ICommand<TParams, TResult>
{
    Task<TResult> ExecuteAsync(TParams parameters);
}