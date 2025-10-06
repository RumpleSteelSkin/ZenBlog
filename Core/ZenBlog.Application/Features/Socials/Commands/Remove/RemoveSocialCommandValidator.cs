using FluentValidation;

namespace ZenBlog.Application.Features.Socials.Commands.Remove;

public class RemoveSocialCommandValidator : AbstractValidator<RemoveSocialCommand>
{
    public RemoveSocialCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id cannot be empty");
    }
}