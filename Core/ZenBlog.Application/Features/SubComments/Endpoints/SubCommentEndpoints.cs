using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ZenBlog.Application.Features.SubComments.Commands.Create;
using ZenBlog.Application.Features.SubComments.Queries.GetAllSubComments;

namespace ZenBlog.Application.Features.SubComments.Endpoints;

public static class SubCommentEndpoints
{
    public static void RegisterSubCommentEndpoints(this IEndpointRouteBuilder app)
    {
        var subComments = app.MapGroup("/subcomments").WithTags("SubComments");
        subComments.MapPost(string.Empty, async (IMediator mediator, CreateSubCommentCommand command) =>
        {
            var response = await mediator.Send(command);
            return response.IsSuccess ? Results.Ok(response) : Results.NotFound(response);
        });

        subComments.MapGet(string.Empty, async (IMediator mediator) =>
        {
            var response = await mediator.Send(new GetAllSubCommentsQuery());
            return response.IsSuccess ? Results.Ok(response) : Results.NotFound(response);
        });
    }
}