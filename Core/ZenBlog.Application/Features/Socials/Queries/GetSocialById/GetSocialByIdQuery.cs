using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Socials.Queries.GetSocialById;

public record GetSocialByIdQuery(Guid Id) : IRequest<BaseResult<GetSocialByIdQueryResponseDto>>;