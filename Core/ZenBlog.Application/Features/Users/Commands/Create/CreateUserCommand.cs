using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Users.Commands.Create;

public class CreateUserCommand : IRequest<BaseResult<object>>
{
    public string? UserName { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
}