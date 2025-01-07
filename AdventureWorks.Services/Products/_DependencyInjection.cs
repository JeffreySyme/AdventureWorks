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
        services.AddScoped<CreateProduct>();
        services.AddScoped<FindProduct>();
        services.AddScoped<QueryProducts>();
        services.AddScoped<UpdateProduct>();

        services.AddScoped<IValidator<ProductModel>, Validator>();

        return services;
    }
}
