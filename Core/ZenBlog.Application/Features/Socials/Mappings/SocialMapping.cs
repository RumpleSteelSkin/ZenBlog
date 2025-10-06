using AutoMapper;
using ZenBlog.Application.Features.Socials.Commands.Create;
using ZenBlog.Application.Features.Socials.Commands.Update;
using ZenBlog.Application.Features.Socials.Queries.GetAllSocials;
using ZenBlog.Application.Features.Socials.Queries.GetSocialById;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Socials.Mappings;

public class SocialMapping : Profile
{
    public SocialMapping()
    {
        CreateMap<CreateSocialCommand, Social>();
        CreateMap<UpdateSocialCommand, Social>();

        CreateMap<Social, GetAllSocialsQueryResponseDto>();
        CreateMap<Social, GetSocialByIdQueryResponseDto>();
    }
}