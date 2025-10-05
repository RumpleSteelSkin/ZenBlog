using AutoMapper;
using ZenBlog.Application.Features.Comments.Queries.GetAllComments;
using ZenBlog.Application.Features.DTOs;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Comments.Mappings;

public class CommentMapping : Profile
{
    public CommentMapping()
    {
        CreateMap<Comment, GetAllCommentsQueryResponseDto>();
        CreateMap<Blog, BlogDto>();
        CreateMap<Comment, CommentDto>();
        CreateMap<AppUser, UserDto>();
    }
}