using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.DTOs;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Users.Queries.LoginUser;

public class LoginUserQueryHandler(UserManager<AppUser> userManager, IJwtService jwtService, IMapper mapper)
    : IRequestHandler<LoginUserQuery, BaseResult<LoginUserQueryResponseDto>>
{
    public async Task<BaseResult<LoginUserQueryResponseDto>> Handle(LoginUserQuery request,
        CancellationToken cancellationToken)
    {
        var usernameOrEmail = request.UsernameOrEmail!.Trim();
        var user = usernameOrEmail.Contains('@')
            ? await userManager.FindByEmailAsync(usernameOrEmail)
            : await userManager.FindByNameAsync(usernameOrEmail);
        if (user is null) return BaseResult<LoginUserQueryResponseDto>.Fail("Invalid credentials");
        var result = await userManager.CheckPasswordAsync(user, request.Password ?? string.Empty);
        if (!result) return BaseResult<LoginUserQueryResponseDto>.Fail("Invalid credentials");
        var userResult = mapper.Map<UserDto>(user);
        var response = await jwtService.GenerateTokenAsync(userResult);
        return response != null
            ? BaseResult<LoginUserQueryResponseDto>.Success(response)
            : BaseResult<LoginUserQueryResponseDto>.Fail("Token could not be generated");
    }
}