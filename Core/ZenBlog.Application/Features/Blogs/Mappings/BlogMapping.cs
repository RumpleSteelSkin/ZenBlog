using AutoMapper;
using ZenBlog.Application.Features.Blogs.Queries.GetAllBlogs;
using ZenBlog.Application.Features.Dtos;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Blogs.Mappings;

public class BlogMapping : Profile
{
    public BlogMapping()
    {
        CreateMap<Category, CategoryDto>();
        CreateMap<Category, GetAllBlogsQueryResponseDto>();
    }
}