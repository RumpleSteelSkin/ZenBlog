using FluentValidation;

namespace ZenBlog.Application.Features.ContactInfos.Commands.Remove;

public class RemoveContactInfoCommandValidator : AbstractValidator<RemoveContactInfoCommand>
{
    public RemoveContactInfoCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("Id required");
    }
}