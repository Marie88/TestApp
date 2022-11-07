using FluentValidation;
using TestApp.BuildingBlocks.Application.Commands;

namespace TestApp.Module.Prod.Application.DraftProduct
{
    internal class DraftProductCommandValidator : CommandValidatorBase<DraftProductCommand>
    {
        public DraftProductCommandValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("Product Id cannot be empty");
        }
    }
}