using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.SubComments.Queries.GetAllSubComments;

public class GetAllSubCommentsQuery : IRequest<BaseResult<ICollection<GetAllSubCommentsQueryResponseDto>>>;