using AdventureWorks.Models;
using FluentValidation;

namespace AdventureWorks.Services.ProductCategories;
internal class Validator : AbstractValidator<ProductCategoryModel>
{
    public Validator()
    {
        RuleFor(x => x.ParentProductCategoryId)
            .GreaterThan(0)
            .When(x => x.ParentProductCategoryId.HasValue)
            .WithMessage("This field must be strictly greater than 0.");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("This field is required.");
    }
}
