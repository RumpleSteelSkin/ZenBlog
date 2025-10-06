using FluentValidation;

namespace ZenBlog.Application.Features.SubComments.Commands.Remove;

public class RemoveSubCommentCommandValidator : AbstractValidator<RemoveSubCommentCommand>
{
    public RemoveSubCommentCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("SubCommentId is required");
    }
}