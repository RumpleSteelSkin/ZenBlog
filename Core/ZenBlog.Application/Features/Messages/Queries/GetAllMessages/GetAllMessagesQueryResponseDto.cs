using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Messages.Queries.GetAllMessages;

public class GetAllMessagesQueryResponseDto : BaseDto
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Subject { get; set; }
    public string? MessageBody { get; set; }
    public bool IsRead { get; set; }
}