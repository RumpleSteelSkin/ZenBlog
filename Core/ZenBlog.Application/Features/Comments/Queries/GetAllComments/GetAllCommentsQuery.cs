using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Comments.Queries.GetAllComments;

public record GetAllCommentsQuery : IRequest<BaseResult<ICollection<GetAllCommentsQueryResponseDto>>>;