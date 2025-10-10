using ZenBlog.Application.Features.DTOs;

namespace ZenBlog.Application.Features.Categories.Queries.GetAllCategoriesWithBlogs;

public class GetAllCategoriesWithBlogsQueryResponseDto
{
    public string? Name { get; set; }
    public ICollection<BlogDto>? Blogs { get; set; }
}