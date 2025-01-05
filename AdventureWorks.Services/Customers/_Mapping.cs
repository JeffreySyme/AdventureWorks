using AdventureWorks.Data.Entities;
using AdventureWorks.Models;

namespace AdventureWorks.Services.Customers;
internal static class Mapping
{
    public static IQueryable<CustomerModel> ProjectToModel(this IQueryable<Customer> entities) 
    {
        return entities.Select(e => new CustomerModel
        {
            CustomerId = e.CustomerId,
            NameStyle = e.NameStyle,
            Title = e.Title,
            FirstName = e.FirstName,
            MiddleName = e.MiddleName,
            LastName = e.LastName,
            Suffix = e.Suffix,
            CompanyName = e.CompanyName,
            SalesPerson = e.SalesPerson,
            EmailAddress = e.EmailAddress,
            Phone = e.Phone,
            ModifiedDate = e.ModifiedDate,
        });
    }

    public static void MapToEntity(this CustomerModel model, Customer entity) 
    {
        model.CustomerId = entity.CustomerId;
        model.NameStyle = entity.NameStyle;
        model.Title = entity.Title;
        model.FirstName = entity.FirstName;
        model.MiddleName = entity.MiddleName;
        model.LastName = entity.LastName;
        model.Suffix = entity.Suffix;
        model.CompanyName = entity.CompanyName;
        model.SalesPerson = entity.SalesPerson;
        model.EmailAddress = entity.EmailAddress;
        model.Phone = entity.Phone;
        model.ModifiedDate = DateTime.Now;
    }
}