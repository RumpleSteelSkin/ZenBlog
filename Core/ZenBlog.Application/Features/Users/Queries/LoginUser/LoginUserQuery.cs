using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Users.Queries.LoginUser;

public record LoginUserQuery : IRequest<BaseResult<LoginUserQueryResponseDto>>
{
    public string? UsernameOrEmail { get; init; }
    public string? Password { get; init; }
}