using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Categories.Commands.Remove;

public record RemoveCategoryCommand(Guid Id) : IRequest<BaseResult<bool>>;