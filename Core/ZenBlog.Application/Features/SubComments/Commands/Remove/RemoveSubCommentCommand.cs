using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.SubComments.Commands.Remove;

public record RemoveSubCommentCommand(Guid Id) : IRequest<BaseResult<object>>;