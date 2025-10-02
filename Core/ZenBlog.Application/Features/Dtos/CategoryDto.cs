using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Dtos;

public class CategoryDto : BaseDto
{
    public string? Name { get; set; }
}