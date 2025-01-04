namespace AdventureWorks.Services;
internal interface IQuery<TResult>
{
    IQueryable<TResult> Execute();
}
