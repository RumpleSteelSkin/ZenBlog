using AutoMapper;
using ZenBlog.Application.Features.Messages.Commands.Create;
using ZenBlog.Application.Features.Messages.Commands.Update;
using ZenBlog.Application.Features.Messages.Queries.GetAllMessages;
using ZenBlog.Application.Features.Messages.Queries.GetMessageById;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Messages.Mappings;

public class MessageMapping : Profile
{
    public MessageMapping()
    {
        CreateMap<CreateMessageCommand, Message>();
        CreateMap<UpdateMessageCommand, Message>();

        CreateMap<Message, GetAllMessagesQueryResponseDto>();
        CreateMap<Message, GetMessageByIdQueryResponseDto>();
    }
}