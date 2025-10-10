using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Blogs.Queries.GetLastBlogsByCount;

public class GetLastBlogsByCountQueryResponseDto : BaseDto
{
    public string? Title { get; set; }
    public string? CoverImage { get; set; }
    public string? BlogImage { get; set; }
    public string? Description { get; set; }
}