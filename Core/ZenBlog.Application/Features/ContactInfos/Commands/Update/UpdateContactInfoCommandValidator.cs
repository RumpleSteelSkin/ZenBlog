using FluentValidation;
using ZenBlog.Application.Constants;

namespace ZenBlog.Application.Features.ContactInfos.Commands.Update;

public class UpdateContactInfoCommandValidator : AbstractValidator<UpdateContactInfoCommand>
{
    public UpdateContactInfoCommandValidator()
    {
        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("Address is required.")
            .MaximumLength(250).WithMessage("Address must not exceed 250 characters.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");

        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("Phone number is required.")
            .Matches(ValidationConstants.PhoneNumber).WithMessage("Phone number contains invalid characters.")
            .MaximumLength(20).WithMessage("Phone number must not exceed 20 characters.");

        RuleFor(x => x.MapUrl)
            .NotEmpty().WithMessage("Map URL is required.");
    }
}