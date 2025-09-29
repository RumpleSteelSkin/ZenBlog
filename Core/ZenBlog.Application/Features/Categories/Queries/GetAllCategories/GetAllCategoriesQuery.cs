using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Categories.Queries.GetAllCategories;

public class GetAllCategoriesQuery : IRequest<BaseResult<ICollection<GetAllCategoriesQueryResponseDto>>>;