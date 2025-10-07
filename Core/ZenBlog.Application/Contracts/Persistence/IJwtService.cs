using ZenBlog.Application.Features.DTOs;
using ZenBlog.Application.Features.Users.Queries.LoginUser;

namespace ZenBlog.Application.Contracts.Persistence;

public interface IJwtService
{
    Task<LoginUserQueryResponseDto?> GenerateTokenAsync(UserDto result);
}