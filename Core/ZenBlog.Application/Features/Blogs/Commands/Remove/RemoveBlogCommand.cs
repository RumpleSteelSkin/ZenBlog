using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Blogs.Commands.Remove;

public record RemoveBlogCommand(Guid Id) : IRequest<BaseResult<bool>>;