using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Categories.Queries.GetAllCategories;

public class GetAllCategoriesQueryHandler(IRepository<Category> repository, IMapper mapper)
    : IRequestHandler<GetAllCategoriesQuery,
        BaseResult<ICollection<GetAllCategoriesQueryResponseDto>>>
{
    public async Task<BaseResult<ICollection<GetAllCategoriesQueryResponseDto>>> Handle(GetAllCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        var categories = await repository.GetAllAsync();
        var response = mapper.Map<ICollection<GetAllCategoriesQueryResponseDto>>(categories);
        return BaseResult<ICollection<GetAllCategoriesQueryResponseDto>>.Success(response);
    }
}