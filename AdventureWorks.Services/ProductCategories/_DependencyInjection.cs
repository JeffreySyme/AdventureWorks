using AdventureWorks.Models;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace AdventureWorks.Services.ProductCategories;

[ExcludeFromCodeCoverage]
internal static class DependencyInjection
{
    public static IServiceCollection AddProductCategories(this IServiceCollection services) 
    {
        services.AddScoped<ICreateProductCategory, CreateProductCategory>();
        services.AddScoped<IFindProductCategory, FindProductCategory>();
        services.AddScoped<IQueryProductCategories, QueryProductCategories>();
        services.AddScoped<IUpdateProductCategory, UpdateProductCategory>();

        services.AddScoped<IValidator<ProductCategoryModel>, Validator>();

        return services;
    }
}
