using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Comments.Commands.Remove;

public record RemoveCommentCommand(Guid Id) : IRequest<BaseResult<object>>;