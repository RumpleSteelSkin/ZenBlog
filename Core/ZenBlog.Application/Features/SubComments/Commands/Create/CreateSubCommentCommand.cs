using System.Text.Json.Serialization;
using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.SubComments.Commands.Create;

public class CreateSubCommentCommand : IRequest<BaseResult<object>>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Body { get; set; }
    [JsonIgnore] public DateTime CommentDate { get; set; } = DateTime.UtcNow;
    public Guid CommentId { get; set; }
}