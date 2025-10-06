using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.SubComments.Queries.GetSubCommentById;

public class GetSubCommentByIdQueryHandler(IMapper mapper, IRepository<SubComment> repository)
    : IRequestHandler<GetSubCommentByIdQuery, BaseResult<GetSubCommentByIdQueryResponseDto>>
{
    public async Task<BaseResult<GetSubCommentByIdQueryResponseDto>> Handle(GetSubCommentByIdQuery request,
        CancellationToken cancellationToken)
    {
        var result = await repository.GetByIdAsync(request.Id);
        var response = mapper.Map<GetSubCommentByIdQueryResponseDto>(result);
        return BaseResult<GetSubCommentByIdQueryResponseDto>.Success(response);
    }
}