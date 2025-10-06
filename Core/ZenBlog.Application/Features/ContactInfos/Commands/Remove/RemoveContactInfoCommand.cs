using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.ContactInfos.Commands.Remove;

public record RemoveContactInfoCommand(Guid Id) : IRequest<BaseResult<object>>;