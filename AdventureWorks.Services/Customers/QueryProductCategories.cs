using AdventureWorks.Data;
using AdventureWorks.Models;

namespace AdventureWorks.Services.Customers;
internal interface IQueryCustomers : IQuery<CustomerModel> { }
internal class QueryCustomers(AdventureWorksDbContext db) : IQueryCustomers
{
    public IQueryable<CustomerModel> Execute()
    {
        return db.Customers.ProjectToModel();
    }
}