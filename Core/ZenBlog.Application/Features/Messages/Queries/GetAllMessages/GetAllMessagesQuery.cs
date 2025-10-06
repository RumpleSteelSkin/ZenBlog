using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Messages.Queries.GetAllMessages;

public class GetAllMessagesQuery : IRequest<BaseResult<ICollection<GetAllMessagesQueryResponseDto>>>;