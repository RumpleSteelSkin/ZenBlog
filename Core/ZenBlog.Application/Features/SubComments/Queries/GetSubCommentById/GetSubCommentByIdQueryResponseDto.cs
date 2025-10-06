using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.SubComments.Queries.GetSubCommentById;

public class GetSubCommentByIdQueryResponseDto : BaseDto
{
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string? Email { get; init; }
    public string? Body { get; init; }
    public DateTime CommentDate { get; init; }
    public Guid CommentId { get; init; }
}