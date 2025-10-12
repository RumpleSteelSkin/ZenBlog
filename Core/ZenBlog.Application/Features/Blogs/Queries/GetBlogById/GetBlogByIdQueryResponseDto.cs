using ZenBlog.Application.Base;
using ZenBlog.Application.Features.DTOs;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Blogs.Queries.GetBlogById;

public class GetBlogByIdQueryResponseDto : BaseDto
{
    public string? Title { get; set; }
    public string? CoverImage { get; set; }
    public string? BlogImage { get; set; }
    public string? Description { get; set; }

    public Guid CategoryId { get; set; }
    public CategoryDto? Category { get; set; }
    public string? UserId { get; set; }
    public AppUser? User { get; set; }
    public ICollection<Comment>? Comments { get; set; }
}