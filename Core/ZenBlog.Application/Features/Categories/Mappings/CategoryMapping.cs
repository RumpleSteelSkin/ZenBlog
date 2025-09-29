using AutoMapper;
using ZenBlog.Application.Features.Categories.Queries.GetAllCategories;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Categories.Mappings;

public class CategoryMapping : Profile
{
    public CategoryMapping()
    {
        CreateMap<Category, GetAllCategoriesQueryResponseDto>();
    }
}