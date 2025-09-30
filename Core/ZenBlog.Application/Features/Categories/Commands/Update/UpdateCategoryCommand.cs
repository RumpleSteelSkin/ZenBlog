using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Categories.Commands.Update;

public record UpdateCategoryCommand(Guid Id, string Name) : IRequest<BaseResult<bool>>;