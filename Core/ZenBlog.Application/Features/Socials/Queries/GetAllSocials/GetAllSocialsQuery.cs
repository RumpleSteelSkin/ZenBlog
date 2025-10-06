using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Socials.Queries.GetAllSocials;

public class GetAllSocialsQuery : IRequest<BaseResult<ICollection<GetAllSocialsQueryResponseDto>>>;