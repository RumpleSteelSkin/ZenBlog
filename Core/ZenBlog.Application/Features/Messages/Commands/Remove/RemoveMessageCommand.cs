using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Messages.Commands.Remove;

public record RemoveMessageCommand(Guid Id) : IRequest<BaseResult<object>>;