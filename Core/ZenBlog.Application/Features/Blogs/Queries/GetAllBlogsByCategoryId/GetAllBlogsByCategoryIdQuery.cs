using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Blogs.Queries.GetAllBlogsByCategoryId;

public record GetAllBlogsByCategoryIdQuery(Guid Id) : IRequest<BaseResult<ICollection<GetAllBlogsByCategoryIdQueryResponseDto>>>;