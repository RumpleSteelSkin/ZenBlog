using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Categories.Queries.GetAllCategoriesWithBlogs;

public class GetAllCategoriesWithBlogsQueryHandler(IRepository<Category> repository, IMapper mapper)
    : IRequestHandler<GetAllCategoriesWithBlogsQuery,
        BaseResult<ICollection<GetAllCategoriesWithBlogsQueryResponseDto>>>
{
    public async Task<BaseResult<ICollection<GetAllCategoriesWithBlogsQueryResponseDto>>> Handle(
        GetAllCategoriesWithBlogsQuery request, CancellationToken cancellationToken)
    {
        var categories = await repository.GetAllAsync();
        var response = mapper.Map<ICollection<GetAllCategoriesWithBlogsQueryResponseDto>>(categories);
        return BaseResult<ICollection<GetAllCategoriesWithBlogsQueryResponseDto>>.Success(response);
    }
}