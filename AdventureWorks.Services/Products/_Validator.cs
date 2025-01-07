using AdventureWorks.Models;
using FluentValidation;

namespace AdventureWorks.Services.Products;
internal class Validator : AbstractValidator<ProductModel>
{
    public Validator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("This field is required.");

        RuleFor(x => x.ProductNumber)
            .NotEmpty()
            .WithMessage("This field is required.")
            .MaximumLength(25)
            .WithMessage("This field must be 25 characters or less.");

        RuleFor(x => x.Color)
            .MaximumLength(15)
            .WithMessage("This field must be 15 characters or less.");

        RuleFor(x => x.StandardCost)
            .GreaterThan(0)
            .WithMessage("This field must be greater than 0.");

        RuleFor(x => x.ListPrice)
            .GreaterThan(0)
            .WithMessage("This field must be greater than 0.");

        RuleFor(x => x.Weight)
            .GreaterThan(0)
            .WithMessage("This field must be greater than 0.");

        RuleFor(x => x.ProductCategoryId)
            .GreaterThan(0)
            .WithMessage("This field must be greater than 0.");

        RuleFor(x => x.ProductModelId)
            .GreaterThan(0)
            .WithMessage("This field must be greater than 0.");

        RuleFor(x => x.SellEndDate)
            .GreaterThan(x => x.SellStartDate)
            .When(x => x.SellEndDate.HasValue)
            .WithMessage("Sell end date must be greater than the sell start date.");

        RuleFor(x => x.DiscontinuedDate)
            .GreaterThan(x => x.SellStartDate)
            .When(x => x.DiscontinuedDate.HasValue)
            .WithMessage("Discontinued date must be greater than the sell start date.");
    }
}
