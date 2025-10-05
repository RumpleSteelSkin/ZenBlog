using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.DTOs;

public class BlogDto : BaseDto
{
    public string? Title { get; set; }
    public string? CoverImage { get; set; }
    public string? BlogImage { get; set; }
    public string? Description { get; set; }
    public Guid CategoryId { get; set; }
    public CategoryDto? Category { get; set; }
    public string? UserId { get; set; }
    public UserDto? User { get; set; }
    public IList<CommentDto>? Comments { get; set; }
}