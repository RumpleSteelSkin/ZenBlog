using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.ContactInfos.Queries.GetAllContactInfos;

public class GetAllContactInfosQueryResponseDto : BaseDto
{
    public string? Address { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? MapUrl { get; set; }
}