using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Messages.Queries.GetAllMessages;

public class GetAllMessagesQueryHandler(IMapper mapper, IRepository<Message> repository)
    : IRequestHandler<GetAllMessagesQuery, BaseResult<ICollection<GetAllMessagesQueryResponseDto>>>
{
    public async Task<BaseResult<ICollection<GetAllMessagesQueryResponseDto>>> Handle(GetAllMessagesQuery request,
        CancellationToken cancellationToken)
    {
        var messages = await repository.GetAllAsync();
        var response = mapper.Map<ICollection<GetAllMessagesQueryResponseDto>>(messages);
        return BaseResult<ICollection<GetAllMessagesQueryResponseDto>>.Success(response);
    }
}