using AdventureWorks.Models;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace AdventureWorks.Services.Products;

[ExcludeFromCodeCoverage]
internal static class DependencyInjection
{
    public static IServiceCollection AddProducts(this IServiceCollection services) 
    {
        services.AddScoped<ICreateProduct, CreateProduct>();
        services.AddScoped<IFindProduct, FindProduct>();
        services.AddScoped<IQueryProducts, QueryProducts>();
        services.AddScoped<IUpdateProduct, UpdateProduct>();

        services.AddScoped<IValidator<ProductModel>, Validator>();

        return services;
    }
}
