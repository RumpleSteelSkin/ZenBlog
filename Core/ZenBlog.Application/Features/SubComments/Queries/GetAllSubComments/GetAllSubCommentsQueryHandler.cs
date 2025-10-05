using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.SubComments.Queries.GetAllSubComments;

public class GetAllSubCommentsQueryHandler(IMapper mapper, IRepository<SubComment> repository)
    : IRequestHandler<GetAllSubCommentsQuery, BaseResult<ICollection<GetAllSubCommentsQueryResponseDto>>>
{
    public async Task<BaseResult<ICollection<GetAllSubCommentsQueryResponseDto>>> Handle(GetAllSubCommentsQuery request,
        CancellationToken cancellationToken)
    {
        var subComments = await repository.GetAllAsync();
        var response = mapper.Map<ICollection<GetAllSubCommentsQueryResponseDto>>(subComments);
        return BaseResult<ICollection<GetAllSubCommentsQueryResponseDto>>.Success(response);
    }
}