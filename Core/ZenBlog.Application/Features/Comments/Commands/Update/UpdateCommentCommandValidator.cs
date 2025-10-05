using FluentValidation;
using ZenBlog.Application.Constants;

namespace ZenBlog.Application.Features.Comments.Commands.Update;

public class UpdateCommentCommandValidator : AbstractValidator<UpdateCommentCommand>
{
    public UpdateCommentCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .Matches(ValidationConstants.NormalCharacters).WithMessage("First name can only contain letters.")
            .MaximumLength(50).WithMessage("First name must not exceed 50 characters.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .Matches(ValidationConstants.NormalCharacters).WithMessage("Last name can only contain letters.")
            .MaximumLength(50).WithMessage("Last name must not exceed 50 characters.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Email must be a valid email address.")
            .MaximumLength(100).WithMessage("Email must not exceed 100 characters.");

        RuleFor(x => x.Body)
            .NotEmpty().WithMessage("Comment body is required.")
            .MinimumLength(3).WithMessage("Comment body must be at least 3 characters long.")
            .MaximumLength(1000).WithMessage("Comment body must not exceed 1000 characters.");

        RuleFor(x => x.BlogId)
            .NotEqual(Guid.Empty).WithMessage("Blog ID must be valid.");
    }
}