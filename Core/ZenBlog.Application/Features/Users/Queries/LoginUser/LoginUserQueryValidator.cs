using FluentValidation;

namespace ZenBlog.Application.Features.Users.Queries.LoginUser;

public class LoginUserQueryValidator : AbstractValidator<LoginUserQuery>
{
    public LoginUserQueryValidator()
    {
        RuleFor(x => x.UsernameOrEmail)
            .NotEmpty().WithMessage("Username or email is required");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required");
    }
}