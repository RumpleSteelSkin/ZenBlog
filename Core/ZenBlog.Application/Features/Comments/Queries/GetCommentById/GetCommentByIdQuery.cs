using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Comments.Queries.GetCommentById;

public record GetCommentByIdQuery(Guid Id) : IRequest<BaseResult<GetCommentByIdQueryResponseDto>>;