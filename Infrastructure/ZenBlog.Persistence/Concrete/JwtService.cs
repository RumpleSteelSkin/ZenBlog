using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.DTOs;
using ZenBlog.Application.Features.Users.Queries.LoginUser;
using ZenBlog.Application.Options;
using ZenBlog.Domain.Entities;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace ZenBlog.Persistence.Concrete;

public class JwtService(UserManager<AppUser> userManager, IOptions<JwtTokenOptions> tokenOptions) : IJwtService
{
    public async Task<LoginUserQueryResponseDto?> GenerateTokenAsync(UserDto result)
    {
        var user = await userManager.FindByNameAsync(result.UserName ?? string.Empty);
        if (user is null) return null;

        SymmetricSecurityKey symmetricSecurityKey = new(Encoding.UTF8.GetBytes(tokenOptions.Value.Key!));
        var dateTimeNow = DateTime.UtcNow;

        List<Claim> claims =
        [
            new(JwtRegisteredClaimNames.Name, user.UserName!),
            new(JwtRegisteredClaimNames.Sub, user.Id),
            new(JwtRegisteredClaimNames.Email, user.Email!),
            new("fullName", string.Join(" ", user.FirstName, user.LastName))
        ];

        JwtSecurityToken jwtSecurityToken = new(
            issuer: tokenOptions.Value.Issuer,
            audience: tokenOptions.Value.Audience,
            claims: claims,
            notBefore: dateTimeNow.AddSeconds(-5),
            expires: dateTimeNow.AddMinutes(Math.Max(1, tokenOptions.Value.ExpireInMinute)), 
            signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
        );

        LoginUserQueryResponseDto response = new()
        {
            Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
            ExpirationTime = dateTimeNow.AddMinutes(tokenOptions.Value.ExpireInMinute)
        };

        return response;
    }
}