using AutoMapper;
using ZenBlog.Application.Features.DTOs;
using ZenBlog.Application.Features.Users.Commands.Create;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Users.Mappings;

public class UserMapping : Profile
{
    public UserMapping()
    {
        CreateMap<CreateUserCommand, AppUser>();
        CreateMap<AppUser, UserDto>();
    }
}