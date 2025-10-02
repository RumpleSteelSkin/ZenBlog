using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Blogs.Queries.GetBlogById;

public class GetBlogByIdQueryHandler(IMapper mapper, IRepository<Blog> repository)
    : IRequestHandler<GetBlogByIdQuery, BaseResult<GetBlogByIdQueryResponseDto>>
{
    public async Task<BaseResult<GetBlogByIdQueryResponseDto>> Handle(GetBlogByIdQuery request,
        CancellationToken cancellationToken)
    {
        var blog = await repository.GetByIdAsync(request.Id);
        if (blog is null) return BaseResult<GetBlogByIdQueryResponseDto>.Fail("Blog not found");
        var response = mapper.Map<GetBlogByIdQueryResponseDto>(blog);
        return BaseResult<GetBlogByIdQueryResponseDto>.Success(response);
    }
}