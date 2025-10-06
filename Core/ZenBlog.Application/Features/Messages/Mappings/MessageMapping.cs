using AutoMapper;
using ZenBlog.Application.Features.Messages.Commands.Create;
using ZenBlog.Application.Features.Messages.Queries.GetAllMessages;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Messages.Mappings;

public class MessageMapping : Profile
{
    public MessageMapping()
    {
        CreateMap<CreateMessageCommand, Message>();

        CreateMap<Message, GetAllMessagesQueryResponseDto>();
    }
}