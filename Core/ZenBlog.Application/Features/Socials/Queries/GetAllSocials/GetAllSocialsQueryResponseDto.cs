using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Socials.Queries.GetAllSocials;

public class GetAllSocialsQueryResponseDto : BaseDto
{
    public string? Title { get; init; }
    public string? Url { get; init; }
    public string? Icon { get; init; }
}