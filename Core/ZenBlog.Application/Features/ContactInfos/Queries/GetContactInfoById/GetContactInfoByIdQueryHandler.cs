using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.ContactInfos.Queries.GetContactInfoById;

public class GetContactInfoByIdQueryHandler(IMapper mapper, IRepository<ContactInfo> repository)
    : IRequestHandler<GetContactInfoByIdQuery, BaseResult<GetContactInfoByIdQueryResponseDto>>
{
    public async Task<BaseResult<GetContactInfoByIdQueryResponseDto>> Handle(GetContactInfoByIdQuery request,
        CancellationToken cancellationToken)
    {
        var contactInfo = await repository.GetByIdAsync(request.Id);
        if (contactInfo is null) return BaseResult<GetContactInfoByIdQueryResponseDto>.NotFound("Contact info not found");
        var response = mapper.Map<GetContactInfoByIdQueryResponseDto>(contactInfo);
        return BaseResult<GetContactInfoByIdQueryResponseDto>.Success(response);
    }
}