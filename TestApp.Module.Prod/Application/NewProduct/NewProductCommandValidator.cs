using FluentValidation;
using TestApp.BuildingBlocks.Application.Commands;

namespace TestApp.Module.Prod.Application.NewProduct
{
    internal class NewProductCommandValidator : CommandValidatorBase<NewProductCommand>
    {
        public NewProductCommandValidator()
        {
            RuleFor(x => x.Key).NotEmpty().WithMessage("Product Key cannot be empty");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Product Title cannot be empty");
            RuleFor(x => x.Version).NotEmpty().WithMessage("Product Version cannot be empty");
        }
    }
}