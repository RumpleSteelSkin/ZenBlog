using ZenBlog.Application.Base;
using ZenBlog.Application.Features.DTOs;

namespace ZenBlog.Application.Features.Comments.Queries.GetAllComments;

public class GetAllCommentsQueryResponseDto : BaseDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Body { get; set; }
    public DateTime CommentDate { get; set; }
    public Guid BlogId { get; set; }
    public BlogDto? Blog { get; set; }
}