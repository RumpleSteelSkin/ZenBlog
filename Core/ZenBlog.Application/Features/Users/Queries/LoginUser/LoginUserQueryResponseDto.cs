namespace ZenBlog.Application.Features.Users.Queries.LoginUser;

public class LoginUserQueryResponseDto
{
    public string? Token { get; set; }
    public DateTime ExpirationTime { get; set; }
}