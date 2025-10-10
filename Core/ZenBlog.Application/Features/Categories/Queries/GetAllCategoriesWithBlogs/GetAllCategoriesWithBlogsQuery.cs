using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Categories.Queries.GetAllCategoriesWithBlogs;

public record
    GetAllCategoriesWithBlogsQuery : IRequest<BaseResult<ICollection<GetAllCategoriesWithBlogsQueryResponseDto>>>;