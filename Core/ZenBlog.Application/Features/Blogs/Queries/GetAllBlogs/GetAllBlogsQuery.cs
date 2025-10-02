using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Blogs.Queries.GetAllBlogs;

public record GetAllBlogsQuery : IRequest<BaseResult<ICollection<GetAllBlogsQueryResponseDto>>>;