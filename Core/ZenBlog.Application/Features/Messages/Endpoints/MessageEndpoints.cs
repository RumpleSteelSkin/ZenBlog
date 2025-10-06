using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ZenBlog.Application.Features.Messages.Commands.Create;

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
    }
}