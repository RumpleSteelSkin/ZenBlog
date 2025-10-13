using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ZenBlog.Application.Features.Comments.Commands.Create;
using ZenBlog.Application.Features.Comments.Commands.Remove;
using ZenBlog.Application.Features.Comments.Commands.Update;
using ZenBlog.Application.Features.Comments.Queries.GetAllComments;
using ZenBlog.Application.Features.Comments.Queries.GetCommentById;

namespace ZenBlog.Application.Features.Comments.Endpoints;

public static class CommentEndpoints
{
    public static void RegisterCommentEndpoints(this IEndpointRouteBuilder app)
    {
        var comments = app.MapGroup("/comments").WithTags("Comments");
        comments.MapGet(string.Empty, async (IMediator mediator) =>
        {
            var response = await mediator.Send(new GetAllCommentsQuery());
            return response.IsSuccess ? Results.Ok(response) : Results.NotFound(response);
        }).AllowAnonymous();

        comments.MapGet("{id:guid}", async (IMediator mediator, Guid id) =>
        {
            var response = await mediator.Send(new GetCommentByIdQuery(id));
            return response.IsSuccess ? Results.Ok(response) : Results.NotFound(response);
        }).AllowAnonymous();

        comments.MapPost(string.Empty, async (IMediator mediator, CreateCommentCommand command) =>
        {
            var response = await mediator.Send(command);
            return response.IsSuccess ? Results.Ok(response) : Results.NotFound(response);
        }).AllowAnonymous();

        comments.MapPut("{id:guid}", async (IMediator mediator, UpdateCommentCommand command, Guid id) =>
        {
            if (id != command.Id) return Results.BadRequest("ID mismatch between URL and body");
            var response = await mediator.Send(command);
            return response.IsSuccess ? Results.Ok(response) : Results.NotFound(response);
        });

        comments.MapDelete("{id:guid}", async (IMediator mediator, Guid id) =>
        {
            var response = await mediator.Send(new RemoveCommentCommand(id));
            return response.IsSuccess ? Results.Ok(response) : Results.NotFound(response);
        });
    }
}