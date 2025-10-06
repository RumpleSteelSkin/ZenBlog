using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.ContactInfos.Queries.GetAllContactInfos;

public class GetAllContactInfosQueryHandler(IRepository<ContactInfo> repository, IMapper mapper)
    : IRequestHandler<GetAllContactInfosQuery,
        BaseResult<ICollection<GetAllContactInfosQueryResponseDto>>>
{
    public async Task<BaseResult<ICollection<GetAllContactInfosQueryResponseDto>>> Handle(
        GetAllContactInfosQuery request,
        CancellationToken cancellationToken)
    {
        var contactInfos = await repository.GetAllAsync();
        var response = mapper.Map<ICollection<GetAllContactInfosQueryResponseDto>>(contactInfos);
        return BaseResult<ICollection<GetAllContactInfosQueryResponseDto>>.Success(response);
    }
}