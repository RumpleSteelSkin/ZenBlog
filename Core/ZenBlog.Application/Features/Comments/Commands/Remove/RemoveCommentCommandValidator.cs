using FluentValidation;

namespace ZenBlog.Application.Features.Comments.Commands.Remove;

public class RemoveCommentCommandValidator : AbstractValidator<RemoveCommentCommand>
{
    public RemoveCommentCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("Id is required");
    }
}