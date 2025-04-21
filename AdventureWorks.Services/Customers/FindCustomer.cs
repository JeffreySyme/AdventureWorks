using AdventureWorks.Data;
using AdventureWorks.Models;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.Services.Customers;
public interface IFindCustomer : ICommand<int, CustomerModel?> { }
internal class FindCustomer(AdventureWorksDbContext db) : IFindCustomer
{
    public Task<CustomerModel?> ExecuteAsync(int customerId)
    {
        return db.Customers
            .ProjectToModel()
            .FirstOrDefaultAsync(x => x.CustomerId == customerId);
    }
}
