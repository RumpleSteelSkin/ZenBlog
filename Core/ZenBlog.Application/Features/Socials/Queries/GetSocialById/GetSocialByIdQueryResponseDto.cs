using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Socials.Queries.GetSocialById;

public class GetSocialByIdQueryResponseDto : BaseDto
{
    public string? Title { get; set; }
    public string? Url { get; set; }
    public string? Icon { get; set; }
}