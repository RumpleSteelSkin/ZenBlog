using FluentValidation;

namespace ZenBlog.Application.Features.Blogs.Commands.Create;

public class CreateBlogCommandValidator : AbstractValidator<CreateBlogCommand>
{
    public CreateBlogCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotNull().WithMessage("Title cannot be null")
            .NotEmpty().WithMessage("Title is required")
            .MaximumLength(200).WithMessage("Title cannot exceed 200 characters");

        RuleFor(x => x.CoverImage)
            .NotNull().NotEmpty().WithMessage("Cover image is required");

        RuleFor(x => x.BlogImage).NotEmpty().NotNull().WithMessage("Blog image must be a valid URL");
        
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required")
            .MinimumLength(20).WithMessage("Description must be at least 20 characters")
            .MaximumLength(2000).WithMessage("Description cannot exceed 2000 characters");
        
        RuleFor(x => x.CategoryId)
            .NotEmpty().WithMessage("CategoryId is required");
        
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required");
    }
}