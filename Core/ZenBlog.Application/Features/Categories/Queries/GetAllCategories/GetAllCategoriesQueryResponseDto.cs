using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Categories.Queries.GetAllCategories;

public class GetAllCategoriesQueryResponseDto : BaseDto
{
    public string? Name { get; set; }
}