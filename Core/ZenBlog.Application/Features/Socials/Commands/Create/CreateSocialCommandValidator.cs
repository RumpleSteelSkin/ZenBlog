using FluentValidation;

namespace ZenBlog.Application.Features.Socials.Commands.Create;

public class CreateSocialCommandValidator : AbstractValidator<CreateSocialCommand>
{
    public CreateSocialCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(50).WithMessage("Title must not exceed 50 characters.");

        RuleFor(x => x.Url)
            .NotEmpty().WithMessage("URL is required.");

        RuleFor(x => x.Icon)
            .NotEmpty().WithMessage("Icon is required.")
            .MaximumLength(100).WithMessage("Icon must not exceed 100 characters.");
    }
}