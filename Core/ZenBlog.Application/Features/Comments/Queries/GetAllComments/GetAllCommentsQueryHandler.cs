using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Comments.Queries.GetAllComments;

public class GetAllCommentsQueryHandler(IMapper mapper, IRepository<Comment> repository)
    : IRequestHandler<GetAllCommentsQuery,
        BaseResult<ICollection<GetAllCommentsQueryResponseDto>>>
{
    public async Task<BaseResult<ICollection<GetAllCommentsQueryResponseDto>>> Handle(GetAllCommentsQuery request,
        CancellationToken cancellationToken)
    {
        var comments = await repository.GetAllAsync();
        var response = mapper.Map<ICollection<GetAllCommentsQueryResponseDto>>(comments);
        return BaseResult<ICollection<GetAllCommentsQueryResponseDto>>.Success(response);
    }
}