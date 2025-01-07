using AdventureWorks.Models;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;

namespace AdventureWorks.Api.Configuration;
internal static class ODataConfiguration
{
    public static void AddOData(this IMvcBuilder mvcBuilder) 
    {
        var odataBuilder = new ODataConventionModelBuilder();

        odataBuilder.EntitySet<CustomerModel>("Customers");
        odataBuilder.EntitySet<ProductCategoryModel>("ProductCategories");
        odataBuilder.EntitySet<ProductModel>("Products");

        odataBuilder.EnableLowerCamelCase();

        mvcBuilder.AddOData(opts =>
        {
            opts.Select();
            opts.Filter();
            opts.OrderBy();
            opts.SetMaxTop(2000);
            opts.Count();
            opts.AddRouteComponents(odataBuilder.GetEdmModel());
        });
    }
}
