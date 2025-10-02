using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Blogs.Queries.GetAllBlogs;

public class GetAllBlogsQueryHandler(IRepository<Blog> repository, IMapper mapper)
    : IRequestHandler<GetAllBlogsQuery, BaseResult<ICollection<GetAllBlogsQueryResponseDto>>>
{
    public async Task<BaseResult<ICollection<GetAllBlogsQueryResponseDto>>> Handle(GetAllBlogsQuery request,
        CancellationToken cancellationToken)
    {
        var categories = await repository.GetAllAsync();
        var response = mapper.Map<ICollection<GetAllBlogsQueryResponseDto>>(categories);
        return BaseResult<ICollection<GetAllBlogsQueryResponseDto>>.Success(response);
    }
}