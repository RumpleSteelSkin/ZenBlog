using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.SubComments.Queries.GetSubCommentById;

public record GetSubCommentByIdQuery(Guid Id) : IRequest<BaseResult<GetSubCommentByIdQueryResponseDto>>;