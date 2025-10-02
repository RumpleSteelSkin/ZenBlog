using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Blogs.Queries.GetBlogById;

public record GetBlogByIdQuery(Guid Id) : IRequest<BaseResult<GetBlogByIdQueryResponseDto>>;