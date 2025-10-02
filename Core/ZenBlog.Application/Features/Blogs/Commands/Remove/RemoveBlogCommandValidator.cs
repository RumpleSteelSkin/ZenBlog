using FluentValidation;

namespace ZenBlog.Application.Features.Blogs.Commands.Remove;

public class RemoveBlogCommandValidator : AbstractValidator<RemoveBlogCommand>
{
    public RemoveBlogCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
    }
}