using FluentValidation;

namespace ZenBlog.Application.Features.Messages.Commands.Remove;

public class RemoveMessageCommandValidator : AbstractValidator<RemoveMessageCommand>
{
    public RemoveMessageCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id cannot be empty");
    }
}