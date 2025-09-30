using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Categories.Commands.Create;

public record CreateCategoryCommand(string Name) : IRequest<BaseResult<bool>>;