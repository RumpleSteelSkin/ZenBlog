using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.ContactInfos.Queries.GetAllContactInfos;

public class GetAllContactInfosQuery : IRequest<BaseResult<ICollection<GetAllContactInfosQueryResponseDto>>>;