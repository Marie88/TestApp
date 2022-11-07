using FluentValidation;
using TestApp.BuildingBlocks.Application.Commands;

namespace TestApp.Module.Prod.Application.ApproveForUse
{
    internal class ApproveForUseProductCommandValidator : CommandValidatorBase<ApproveForUseProductCommand>
    {
        public ApproveForUseProductCommandValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("Product Id cannot be empty");
        }
    }
}