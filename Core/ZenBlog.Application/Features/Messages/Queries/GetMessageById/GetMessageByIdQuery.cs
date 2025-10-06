using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Messages.Queries.GetMessageById;

public record GetMessageByIdQuery(Guid Id) : IRequest<BaseResult<GetMessageByIdQueryResponseDto>>;