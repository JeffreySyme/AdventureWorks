﻿using AdventureWorks.Models;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace AdventureWorks.Services.ProductCategories;

[ExcludeFromCodeCoverage]
internal static class DependencyInjection
{
    public static IServiceCollection AddProductCategories(this IServiceCollection services) 
    {
        services.AddScoped<CreateProductCategory>();
        services.AddScoped<FindProductCategory>();
        services.AddScoped<QueryProductCategories>();
        services.AddScoped<UpdateProductCategory>();

        services.AddScoped<IValidator<ProductCategoryModel>, Validator>();

        return services;
    }
}
