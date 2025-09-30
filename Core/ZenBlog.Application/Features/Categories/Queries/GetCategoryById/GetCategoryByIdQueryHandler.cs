using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Categories.Queries.GetCategoryById;

public class GetCategoryByIdQueryHandler(IMapper mapper, IRepository<Category> repository)
    : IRequestHandler<GetCategoryByIdQuery, BaseResult<GetCategoryByIdQueryResponseDto>>
{
    public async Task<BaseResult<GetCategoryByIdQueryResponseDto>> Handle(GetCategoryByIdQuery request,
        CancellationToken cancellationToken)
    {
        var category = await repository.GetByIdAsync(request.Id);
        if (category is null) return BaseResult<GetCategoryByIdQueryResponseDto>.NotFound("Category not found");
        var response = mapper.Map<GetCategoryByIdQueryResponseDto>(category);
        return BaseResult<GetCategoryByIdQueryResponseDto>.Success(response);
    }
}