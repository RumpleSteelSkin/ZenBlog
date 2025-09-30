using FluentValidation;

namespace ZenBlog.Application.Features.Categories.Commands.Update;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotNull().NotEmpty().WithMessage("Name is required")
            .MinimumLength(3).WithMessage("Name must be at least 3 characters long");

        RuleFor(x => x.Id)
            .NotNull().NotEmpty().WithMessage("Id is required");
    }
}