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
            Addresses = e.CustomerAddresses.Select(ca => new CustomerAddressModel 
            {
                AddressType = ca.AddressType,
                AddressLine1 = ca.Address.AddressLine1,
                AddressLine2 = ca.Address.AddressLine2,
                City = ca.Address.City,
                StateProvince = ca.Address.StateProvince,
                CountryRegion = ca.Address.CountryRegion,
                PostalCode = ca.Address.PostalCode,
            })
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

        var customerAddressModelQueue = new Queue<CustomerAddressModel>(model.Addresses);

        foreach (var addressEntity in entity.CustomerAddresses) 
        {
            var customerAddressModel = customerAddressModelQueue.Dequeue();

            if (customerAddressModel == null)
                break;

            addressEntity.AddressType = customerAddressModel.AddressType;
            addressEntity.Address.AddressLine1 = customerAddressModel.AddressLine1;
            addressEntity.Address.AddressLine2 = customerAddressModel.AddressLine2;
            addressEntity.Address.City = customerAddressModel.City;
            addressEntity.Address.StateProvince = customerAddressModel.StateProvince;
            addressEntity.Address.CountryRegion = customerAddressModel.CountryRegion;
            addressEntity.ModifiedDate = DateTime.Now;
        }

        foreach (var customerAddressModel in customerAddressModelQueue) 
        {
            entity.CustomerAddresses.Add(new CustomerAddress
            {
                AddressType = customerAddressModel.AddressType,
                Address = new Address 
                {
                    AddressLine1 = customerAddressModel.AddressLine1,
                    AddressLine2 = customerAddressModel.AddressLine2,
                    City = customerAddressModel.City,
                    StateProvince = customerAddressModel.StateProvince,
                    CountryRegion = customerAddressModel.CountryRegion,
                    PostalCode = customerAddressModel.PostalCode,
                    ModifiedDate = DateTime.Now,
                }
            });
        }
    }
}