using AdventureWorks.Data.Entities;
using AdventureWorks.Models;

namespace AdventureWorks.Services.SalesOrders;

internal static class Mapping
{
    public static IQueryable<SalesOrderModel> ProjectToModel(this IQueryable<SalesOrderHeader> entities)
    {
        return entities.Select(e => new SalesOrderModel
        {
            SalesOrderId = e.SalesOrderId,
            RevisionNumber = e.RevisionNumber,
            OrderDate = e.OrderDate,
            DueDate = e.DueDate,
            ShipDate = e.ShipDate,
            Status = e.Status,
            OnlineOrderFlag = e.OnlineOrderFlag,
            SalesOrderNumber = e.SalesOrderNumber,
            PurchaseOrderNumber = e.PurchaseOrderNumber,
            AccountNumber = e.AccountNumber,
            CustomerId = e.CustomerId,
            ShipToAddress = e.ShipToAddressId.HasValue
                ? new AddressModel
                {
                    AddressLine1 = e.ShipToAddress.AddressLine1,
                    AddressLine2 = e.ShipToAddress.AddressLine2,
                    City = e.ShipToAddress.City,
                    StateProvince = e.ShipToAddress.StateProvince,
                    CountryRegion = e.ShipToAddress.CountryRegion,
                    PostalCode = e.ShipToAddress.PostalCode,
                }
                : null,
            BillToAddress = e.BillToAddressId.HasValue
                ? new AddressModel
                {
                    AddressLine1 = e.BillToAddress.AddressLine1,
                    AddressLine2 = e.BillToAddress.AddressLine2,
                    City = e.BillToAddress.City,
                    StateProvince = e.BillToAddress.StateProvince,
                    CountryRegion = e.BillToAddress.CountryRegion,
                    PostalCode = e.BillToAddress.PostalCode,
                }
                : null,
            ShipMethod = e.ShipMethod,
            CreditCardApprovalCode = e.CreditCardApprovalCode,
            SubTotal = e.SubTotal,
            TaxAmt = e.TaxAmt,
            Freight = e.Freight,
            TotalDue = e.TotalDue,
            Comment = e.Comment,
            ModifiedDate = e.ModifiedDate,
        });
    }
}
