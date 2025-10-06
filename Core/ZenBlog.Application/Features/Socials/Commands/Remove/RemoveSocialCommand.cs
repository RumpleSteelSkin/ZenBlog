using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Socials.Commands.Remove;

public record RemoveSocialCommand(Guid Id) : IRequest<BaseResult<object>>;