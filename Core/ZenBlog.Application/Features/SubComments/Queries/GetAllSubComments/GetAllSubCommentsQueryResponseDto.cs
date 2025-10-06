using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.SubComments.Queries.GetAllSubComments;

public class GetAllSubCommentsQueryResponseDto : BaseDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Body { get; set; }
    public DateTime CommentDate { get; set; }
    public Guid CommentId { get; set; }
}