using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Socials.Queries.GetAllSocials;

public class GetAllSocialsQueryHandler(IMapper mapper, IRepository<Social> repository)
    : IRequestHandler<GetAllSocialsQuery, BaseResult<ICollection<GetAllSocialsQueryResponseDto>>>
{
    public async Task<BaseResult<ICollection<GetAllSocialsQueryResponseDto>>> Handle(GetAllSocialsQuery request,
        CancellationToken cancellationToken)
    {
        var socials = await repository.GetAllAsync();
        var response = mapper.Map<ICollection<GetAllSocialsQueryResponseDto>>(socials);
        return BaseResult<ICollection<GetAllSocialsQueryResponseDto>>.Success(response);
    }
}