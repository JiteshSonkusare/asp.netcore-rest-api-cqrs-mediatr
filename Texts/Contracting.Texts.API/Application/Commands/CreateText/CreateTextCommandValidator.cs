using Texts.API.Application.Infrastructure.Validation;
using FluentValidation;

namespace Texts.API.Application.Commands.CreateText
{
    public class CreateTextCommandValidator : AbstractValidator<CreateTextCommand>
    {
        public CreateTextCommandValidator()
        {
            RuleFor(x => x.Language)
                .MaximumLength(100)
                .NotEmpty();

            RuleFor(x => x.Branch)
                .MaximumLength(100)
                .NotEmpty();

            RuleFor(x => x.Area)
                .MaximumLength(100);

            RuleFor(x => x.Key)
                .MaximumLength(100)
                .NotEmpty()
                .SetValidator(new TextValidator());

            RuleFor(x => x.Value)
                .NotEmpty();
        }
    }
}
