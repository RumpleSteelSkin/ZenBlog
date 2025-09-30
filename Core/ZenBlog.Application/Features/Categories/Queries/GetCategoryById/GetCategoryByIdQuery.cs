using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Categories.Queries.GetCategoryById;

public record GetCategoryByIdQuery(Guid Id) : IRequest<BaseResult<GetCategoryByIdQueryResponseDto>>;