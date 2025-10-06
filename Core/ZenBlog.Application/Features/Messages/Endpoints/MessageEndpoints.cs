using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ZenBlog.Application.Features.Messages.Commands.Create;
using ZenBlog.Application.Features.Messages.Commands.Remove;
using ZenBlog.Application.Features.Messages.Commands.Update;
using ZenBlog.Application.Features.Messages.Queries.GetAllMessages;
using ZenBlog.Application.Features.Messages.Queries.GetMessageById;

namespace ZenBlog.Application.Features.Messages.Endpoints;

public static class MessageEndpoints
{
    public static void RegisterMessageEndpoints(this IEndpointRouteBuilder app)
    {
        var messages = app.MapGroup("/messages").WithTags("Messages");

        messages.MapPost(string.Empty, async (IMediator mediator, CreateMessageCommand command) =>
        {
            var response = await mediator.Send(command);
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });

        messages.MapGet(string.Empty, async (IMediator mediator) =>
        {
            var response = await mediator.Send(new GetAllMessagesQuery());
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });

        messages.MapGet("{id:guid}", async (IMediator mediator, Guid id) =>
        {
            var response = await mediator.Send(new GetMessageByIdQuery(id));
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });

        messages.MapDelete("{id:guid}", async (IMediator mediator, Guid id) =>
        {
            var response = await mediator.Send(new RemoveMessageCommand(id));
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });

        messages.MapPut("{id:guid}", async (IMediator mediator, Guid id, UpdateMessageCommand command) =>
        {
            var response = await mediator.Send(command);
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });
    }
}