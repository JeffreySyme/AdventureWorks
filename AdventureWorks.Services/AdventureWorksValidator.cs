using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace AdventureWorks.Services;
public interface IAdventureWorksValidator 
{
    Task<ValidationResult> ValidateAsync<TParams>(TParams parameters);
}

[ExcludeFromCodeCoverage]
internal class AdventureWorksValidator(IServiceProvider serviceProvider) : IAdventureWorksValidator
{
    public Task<ValidationResult> ValidateAsync<TParams>(TParams parameters)
    {
        return serviceProvider
            .GetRequiredService<IValidator<TParams>>()
            .ValidateAsync(parameters);
    }
}
