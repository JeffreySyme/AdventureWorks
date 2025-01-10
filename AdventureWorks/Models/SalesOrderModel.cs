using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace AdventureWorks.Models;

[ExcludeFromCodeCoverage]
public class SalesOrderModel
{
    [Key]
    public int SalesOrderId { get; set; }
    public byte RevisionNumber { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ShipDate { get; set; }
    public byte Status { get; set; }
    public bool OnlineOrderFlag { get; set; }
    public string SalesOrderNumber { get; set; }
    public string PurchaseOrderNumber { get; set; }
    public string AccountNumber { get; set; }
    public int CustomerId { get; set; }
    public AddressModel ShipToAddress { get; set; }
    public AddressModel BillToAddress { get; set; }
    public string ShipMethod { get; set; }
    public string CreditCardApprovalCode { get; set; }
    public decimal SubTotal { get; set; }
    public decimal TaxAmt { get; set; }
    public decimal Freight { get; set; }
    public decimal TotalDue { get; set; }
    public string Comment { get; set; }
    public DateTime ModifiedDate { get; set; }
    public IEnumerable<SalesOrderDetailModel> SalesOrderDetails { get; set; } = [];
}
