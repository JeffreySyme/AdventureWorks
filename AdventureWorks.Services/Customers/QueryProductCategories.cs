using AdventureWorks.Data;
using AdventureWorks.Models;

namespace AdventureWorks.Services.Customers;
internal class QueryCustomers(AdventureWorksDbContext db) : IQuery<CustomerModel>
{
    public IQueryable<CustomerModel> Execute()
    {
        return db.Customers.ProjectToModel();
    }
}