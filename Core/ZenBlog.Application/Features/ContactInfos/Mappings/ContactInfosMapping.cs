using AutoMapper;
using ZenBlog.Application.Features.ContactInfos.Queries.GetAllContactInfos;
using ZenBlog.Application.Features.ContactInfos.Queries.GetContactInfoById;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.ContactInfos.Mappings;

public class ContactInfosMapping : Profile
{
    public ContactInfosMapping()
    {
        CreateMap<ContactInfo, GetAllContactInfosQueryResponseDto>();
        CreateMap<ContactInfo, GetContactInfoByIdQueryResponseDto>();
    }
}