using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.DTOs;

public class CategoryDto : BaseDto
{
    public string? Name { get; set; }
}