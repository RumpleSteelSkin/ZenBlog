using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.ContactInfos.Queries.GetContactInfoById;

public record GetContactInfoByIdQuery(Guid Id) : IRequest<BaseResult<GetContactInfoByIdQueryResponseDto>>;