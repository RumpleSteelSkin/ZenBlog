using FluentValidation;
using ZenBlog.Application.Constants;

namespace ZenBlog.Application.Features.Messages.Commands.Create;

public class CreateMessageCommandValidator : AbstractValidator<CreateMessageCommand>
{
    public CreateMessageCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .Matches(ValidationConstants.NormalCharacters).WithMessage("Name contains invalid characters.")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");

        RuleFor(x => x.Subject)
            .NotEmpty().WithMessage("Subject is required.")
            .MaximumLength(150).WithMessage("Subject must not exceed 150 characters.");

        RuleFor(x => x.MessageBody)
            .NotEmpty().WithMessage("Message body is required.")
            .MinimumLength(10).WithMessage("Message body must be at least 10 characters long.");
    }
}