using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Socials.Queries.GetSocialById;

public class GetSocialByIdQueryHandler(IRepository<Social> repository, IMapper mapper)
    : IRequestHandler<GetSocialByIdQuery, BaseResult<GetSocialByIdQueryResponseDto>>
{
    public async Task<BaseResult<GetSocialByIdQueryResponseDto>> Handle(GetSocialByIdQuery request,
        CancellationToken cancellationToken)
    {
        var social = await repository.GetByIdAsync(request.Id);
        var dto = mapper.Map<GetSocialByIdQueryResponseDto>(social);
        return BaseResult<GetSocialByIdQueryResponseDto>.Success(dto);
    }
}