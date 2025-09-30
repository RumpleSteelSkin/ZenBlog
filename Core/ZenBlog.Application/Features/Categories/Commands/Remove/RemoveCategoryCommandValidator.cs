using FluentValidation;

namespace ZenBlog.Application.Features.Categories.Commands.Remove;

public class RemoveCategoryCommandValidator : AbstractValidator<RemoveCategoryCommand>
{
    public RemoveCategoryCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
    }
}