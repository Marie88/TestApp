using FluentValidation;
using TestApp.BuildingBlocks.Application.Commands;

namespace TestApp.Module.Prod.Application.DeprecateProduct
{
    internal class DeprecateProductCommandValidator : CommandValidatorBase<DeprecateProductCommand>
    {
        public DeprecateProductCommandValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("Product Id cannot be empty");
        }
    }
}