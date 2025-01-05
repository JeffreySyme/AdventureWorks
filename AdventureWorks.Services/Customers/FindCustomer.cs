using AdventureWorks.Data;
using AdventureWorks.Models;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.Services.Customers;
internal class FindCustomer(AdventureWorksDbContext db) : ICommand<int, CustomerModel?>
{
    public Task<CustomerModel?> ExecuteAsync(int customerId)
    {
        return db.Customers
            .ProjectToModel()
            .FirstOrDefaultAsync(x => x.CustomerId == customerId);
    }
}
