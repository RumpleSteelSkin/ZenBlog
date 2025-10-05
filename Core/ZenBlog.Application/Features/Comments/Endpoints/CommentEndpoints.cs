using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ZenBlog.Application.Features.Comments.Queries.GetAllComments;

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
        });
    }
}