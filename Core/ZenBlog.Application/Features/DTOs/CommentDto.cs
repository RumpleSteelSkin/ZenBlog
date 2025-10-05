using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.DTOs;

public class CommentDto : BaseDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Body { get; set; }
    public DateTime CommentDate { get; set; }
    public Guid BlogId { get; set; }
    public BlogDto? Blog { get; set; }
}