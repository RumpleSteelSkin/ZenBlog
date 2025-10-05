using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Comments.Queries.GetCommentById;

public class GetCommentByIdQueryHandler(IMapper mapper, IRepository<Comment> repository)
    : IRequestHandler<GetCommentByIdQuery, BaseResult<GetCommentByIdQueryResponseDto>>
{
    public async Task<BaseResult<GetCommentByIdQueryResponseDto>> Handle(GetCommentByIdQuery request,
        CancellationToken cancellationToken)
    {
        var result = await repository.GetByIdAsync(request.Id);
        var dto = mapper.Map<GetCommentByIdQueryResponseDto>(result);
        return BaseResult<GetCommentByIdQueryResponseDto>.Success(dto);
    }
}