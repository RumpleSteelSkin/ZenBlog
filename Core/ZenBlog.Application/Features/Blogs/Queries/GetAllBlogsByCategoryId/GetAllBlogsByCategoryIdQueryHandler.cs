using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Blogs.Queries.GetAllBlogsByCategoryId;

public class GetAllBlogsByCategoryIdQueryHandler(IRepository<Blog> repository, IMapper mapper)
    : IRequestHandler<GetAllBlogsByCategoryIdQuery, BaseResult<ICollection<GetAllBlogsByCategoryIdQueryResponseDto>>>
{
    public Task<BaseResult<ICollection<GetAllBlogsByCategoryIdQueryResponseDto>>> Handle(
        GetAllBlogsByCategoryIdQuery request,
        CancellationToken cancellationToken)
    {
        var query = repository.GetQuery().Where(x => x.CategoryId == request.Id).ToList();
        var response = mapper.Map<ICollection<GetAllBlogsByCategoryIdQueryResponseDto>>(query);
        return Task.FromResult(BaseResult<ICollection<GetAllBlogsByCategoryIdQueryResponseDto>>.Success(response));
    }
}