using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Blogs.Queries.GetLastBlogsByCount;

public class GetLastBlogsByCountQueryHandler(IRepository<Blog> repository, IMapper mapper)
    : IRequestHandler<GetLastBlogsByCountQuery, BaseResult<ICollection<GetLastBlogsByCountQueryResponseDto>>>
{
    public Task<BaseResult<ICollection<GetLastBlogsByCountQueryResponseDto>>> Handle(
        GetLastBlogsByCountQuery request,
        CancellationToken cancellationToken)
    {
        var result = repository.GetQuery().OrderByDescending(x => x.CreatedAt).Take(request.Count)
            .ProjectTo<GetLastBlogsByCountQueryResponseDto>(mapper.ConfigurationProvider).ToList();
        return Task.FromResult(BaseResult<ICollection<GetLastBlogsByCountQueryResponseDto>>.Success(result));
    }
}