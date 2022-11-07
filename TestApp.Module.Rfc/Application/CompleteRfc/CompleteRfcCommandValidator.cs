using FluentValidation;

namespace TestApp.Module.Rfc.Application.CompleteRfc;

public class CompleteRfcCommandValidator : AbstractValidator<CompleteRfcCommand>
{
    public CompleteRfcCommandValidator()
    {
        RuleFor(x => x.RfcId).NotEmpty().WithMessage("Rfc key should not be empty");
    }
}