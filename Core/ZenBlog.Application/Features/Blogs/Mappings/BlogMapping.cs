using AutoMapper;
using ZenBlog.Application.Features.Blogs.Commands.Create;
using ZenBlog.Application.Features.Blogs.Commands.Update;
using ZenBlog.Application.Features.Blogs.Queries.GetAllBlogs;
using ZenBlog.Application.Features.Blogs.Queries.GetBlogById;
using ZenBlog.Application.Features.Dtos;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Blogs.Mappings;

public class BlogMapping : Profile
{
    public BlogMapping()
    {
        CreateMap<Category, CategoryDto>();
        CreateMap<Blog, GetAllBlogsQueryResponseDto>();
        CreateMap<Blog, GetBlogByIdQueryResponseDto>();
        

        CreateMap<CreateBlogCommand, Blog>();
        CreateMap<UpdateBlogCommand, Blog>();
    }
}