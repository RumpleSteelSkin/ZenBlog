using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Blogs.Queries.GetLastBlogsByCount;

public record GetLastBlogsByCountQuery(int Count)
    : IRequest<BaseResult<ICollection<GetLastBlogsByCountQueryResponseDto>>>;